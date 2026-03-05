#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

// ========== Configuration ==========
#define WORLD_WIDTH  16
#define WORLD_HEIGHT 16
#define SAVE_FILE    "world.dat"

// Block types
typedef enum {
    BLOCK_AIR,
    BLOCK_DIRT,
    BLOCK_STONE,
    BLOCK_COAL,
    BLOCK_COUNT
} BlockType;

const char BLOCK_CHARS[] = {' ', '.', '#', 'C'};  // visual representation

// Power values for mining each block
const int MINE_POWER[] = {
    0,   // AIR
    0,   // DIRT
    0,   // STONE
    10,  // COAL
};

// Power cost for placing a block
#define PLACE_COST 1

// ========== Global State ==========
BlockType world[WORLD_HEIGHT][WORLD_WIDTH];
int player_x, player_y;      // player coordinates
int power;                   // remaining power (eternal!)

// ========== Function Prototypes ==========
void init_world(void);
void load_game(void);
void save_game(void);
void display_area(void);
void move_player(int dx, int dy);
void break_block(void);
void place_block(void);
int is_valid_position(int x, int y);

// ========== Implementation ==========

void init_world() {
    // Create a simple world: stone base, dirt on top, some coal veins
    for (int y = 0; y < WORLD_HEIGHT; y++) {
        for (int x = 0; x < WORLD_WIDTH; x++) {
            if (y == WORLD_HEIGHT - 1) {
                world[y][x] = BLOCK_STONE;            // bedrock-like bottom
            } else if (y >= WORLD_HEIGHT - 3) {
                world[y][x] = BLOCK_DIRT;              // dirt layer
            } else {
                world[y][x] = BLOCK_AIR;                // upper air
            }
        }
    }
    // Sprinkle some coal near the surface
    world[WORLD_HEIGHT-4][5] = BLOCK_COAL;
    world[WORLD_HEIGHT-4][10] = BLOCK_COAL;
    world[WORLD_HEIGHT-5][7] = BLOCK_COAL;

    // Place player in a safe spot
    player_x = WORLD_WIDTH / 2;
    player_y = WORLD_HEIGHT / 2;
    power = 0;
}

void load_game() {
    FILE *f = fopen(SAVE_FILE, "rb");
    if (!f) {
        // No save file -> start a new world
        init_world();
        return;
    }

    // Read header (simple version check)
    int version;
    fread(&version, sizeof(int), 1, f);
    if (version != 1) {
        // Incompatible version; start fresh
        fclose(f);
        init_world();
        return;
    }

    // Read world dimensions (should match our constants)
    int w, h;
    fread(&w, sizeof(int), 1, f);
    fread(&h, sizeof(int), 1, f);
    if (w != WORLD_WIDTH || h != WORLD_HEIGHT) {
        fclose(f);
        init_world();
        return;
    }

    // Read world data
    fread(world, sizeof(BlockType), WORLD_WIDTH * WORLD_HEIGHT, f);

    // Read player position and power
    fread(&player_x, sizeof(int), 1, f);
    fread(&player_y, sizeof(int), 1, f);
    fread(&power, sizeof(int), 1, f);

    fclose(f);
}

void save_game() {
    FILE *f = fopen(SAVE_FILE, "wb");
    if (!f) {
        printf("Error: Cannot save game!\n");
        return;
    }

    int version = 1;
    fwrite(&version, sizeof(int), 1, f);
    fwrite(&WORLD_WIDTH, sizeof(int), 1, f);
    fwrite(&WORLD_HEIGHT, sizeof(int), 1, f);
    fwrite(world, sizeof(BlockType), WORLD_WIDTH * WORLD_HEIGHT, f);
    fwrite(&player_x, sizeof(int), 1, f);
    fwrite(&player_y, sizeof(int), 1, f);
    fwrite(&power, sizeof(int), 1, f);

    fclose(f);
    printf("Game saved.\n");
}

void display_area() {
    printf("\n--- Area around you (5x5) ---\n");
    for (int dy = -2; dy <= 2; dy++) {
        for (int dx = -2; dx <= 2; dx++) {
            int x = player_x + dx;
            int y = player_y + dy;
            if (x == player_x && y == player_y) {
                printf("@ ");  // player
            } else if (x >= 0 && x < WORLD_WIDTH && y >= 0 && y < WORLD_HEIGHT) {
                printf("%c ", BLOCK_CHARS[world[y][x]]);
            } else {
                printf("# ");  // out of bounds
            }
        }
        printf("\n");
    }
    printf("Power: %d\n", power);
}

int is_valid_position(int x, int y) {
    return (x >= 0 && x < WORLD_WIDTH && y >= 0 && y < WORLD_HEIGHT);
}

void move_player(int dx, int dy) {
    int nx = player_x + dx;
    int ny = player_y + dy;
    if (!is_valid_position(nx, ny)) {
        printf("You cannot leave the world!\n");
        return;
    }
    if (world[ny][nx] != BLOCK_AIR) {
        printf("There is a block in the way!\n");
        return;
    }
    player_x = nx;
    player_y = ny;
    printf("Moved.\n");
}

void break_block() {
    // Assume player is facing north (dy = -1) for simplicity.
    // In a real game you'd track facing direction, but here we'll just break the block above (north).
    int bx = player_x;
    int by = player_y - 1;

    if (!is_valid_position(bx, by)) {
        printf("Nothing to break there.\n");
        return;
    }

    BlockType block = world[by][bx];
    if (block == BLOCK_AIR) {
        printf("No block there.\n");
        return;
    }

    // Gain power
    power += MINE_POWER[block];
    world[by][bx] = BLOCK_AIR;
    printf("You broke %s. Gained %d power. Now you have %d power.\n",
           block == BLOCK_COAL ? "coal" : (block == BLOCK_DIRT ? "dirt" : "stone"),
           MINE_POWER[block], power);
}

void place_block() {
    // Place a dirt block in front of the player (north)
    int bx = player_x;
    int by = player_y - 1;

    if (!is_valid_position(bx, by)) {
        printf("Cannot place there.\n");
        return;
    }
    if (world[by][bx] != BLOCK_AIR) {
        printf("There is already a block there.\n");
        return;
    }
    if (power < PLACE_COST) {
        printf("Not enough power! You need %d power.\n", PLACE_COST);
        return;
    }

    world[by][bx] = BLOCK_DIRT;
    power -= PLACE_COST;
    printf("Placed a dirt block. Power left: %d\n", power);
}

// ========== Main Loop ==========
int main() {
    printf("=== Eternal Minecraft Clone ===\n");
    printf("Commands: w/a/s/d move, b break, p place, status, quit\n");

    load_game();  // loads or initialises

    char input[100];
    while (1) {
        display_area();
        printf("> ");
        fflush(stdout);
        if (!fgets(input, sizeof(input), stdin)) break;

        // Remove trailing newline
        input[strcspn(input, "\n")] = 0;

        if (strcmp(input, "quit") == 0) {
            save_game();
            printf("Goodbye!\n");
            break;
        } else if (strcmp(input, "status") == 0) {
            printf("Position: (%d, %d), Power: %d\n", player_x, player_y, power);
        } else if (strcmp(input, "w") == 0) {
            move_player(0, -1);
        } else if (strcmp(input, "a") == 0) {
            move_player(-1, 0);
        } else if (strcmp(input, "s") == 0) {
            move_player(0, 1);
        } else if (strcmp(input, "d") == 0) {
            move_player(1, 0);
        } else if (strcmp(input, "b") == 0) {
            break_block();
        } else if (strcmp(input, "p") == 0) {
            place_block();
        } else {
            printf("Unknown command.\n");
        }
    }
    return 0;
}