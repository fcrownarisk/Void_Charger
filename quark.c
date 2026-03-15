#include <stdio.h>
#include <string.h>

typedef enum {
    UP,
    DOWN,
    CHARM,
    STRANGE,
    TOP,
    BOTTOM
} QuarkType;

const char* quark_names[] = {
    "Up",
    "Down", 
    "Charm",
    "Strange",
    "Top",
    "Bottom"
};

typedef struct {
    QuarkType type;
    char name[6];
    float mass_mev;
    int electric_charge;
    float isospin_z;
    int baryon_number;
    int strangeness;
    int charm;
    int bottom;
    int top;
} Quark;

void init_quark(Quark* quark, QuarkType type) {
    Quark q = *quark;
    q.type = type;
    strcpy(q.name, quark_names[type]);
    q.baryon_number = 1;
    
    switch(type) {
        case UP:
            q.mass_mev = 2.3;
            q.electric_charge = 2;
            q.isospin_z = 0.5;
            q.strangeness = 0;
            q.charm = 0;
            q.bottom = 0;
            q.top = 0;
            break;
            
        case DOWN:
            q.mass_mev = 4.8;
            q.electric_charge = -1;
            q.isospin_z = -0.5;
            q.strangeness = 0;
            q.charm = 0;
            q.bottom = 0;
            q.top = 0;
            break;
            
        case CHARM:
            q.mass_mev = 1275;
            q.electric_charge = 2;
            q.isospin_z = 0;
            q.strangeness = 0;
            q.charm = 1;
            q.bottom = 0;
            q.top = 0;
            break;
            
        case STRANGE:
            q.mass_mev = 95;
            q.electric_charge = -1;
            q.isospin_z = 0;
            q.strangeness = -1;
            q.charm = 0;
            q.bottom = 0;
            q.top = 0;
            break;
            
        case TOP:
            q.mass_mev = 173000;
            q.electric_charge = 2;
            q.isospin_z = 0;
            q.strangeness = 0;
            q.charm = 0;
            q.bottom = 0;
            q.top = 1;
            break;
            
        case BOTTOM:
            q.mass_mev = 4180;
            q.electric_charge = -1;
            q.isospin_z = 0;
            q.strangeness = 0;
            q.charm = 0;
            q.bottom = -1;
            q.top = 0;
            break;
    }
    *quark = q;
}

void display_all_quarks() {
    Quark quarks[6];
    
    for (int i = 0; i < 6; i++) {
        init_quark(&quarks[i], (QuarkType)i);
    }
}
    return 0;

}
