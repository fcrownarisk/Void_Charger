Imports System
Imports System.Collections.Generic

' Particle type enumeration
Public Enum ParticleType
    ' Fermions (Quarks)
    UpQuark
    DownQuark
    CharmQuark
    StrangeQuark
    TopQuark
    BottomQuark
    
    ' Fermions (Leptons)
    Electron
    Muon
    Tau
    ElectronNeutrino
    MuonNeutrino
    TauNeutrino
    
    ' Gauge Bosons
    Photon
    Gluon
    WPlusBoson
    WMinusBoson
    ZBoson
    
    ' Scalar Bosons
    HiggsBoson
    
    ' Hypothetical/Other
    Graviton
End Enum

' Particle family enumeration
Public Enum ParticleFamily
    Quark
    Lepton
    GaugeBoson
    ScalarBoson
    Hypothetical
End Enum

' Generation enumeration
Public Enum Generation
    First
    Second
    Third
    NotApplicable
End Enum

' Particle class
Public Class Particle
    Public Property Name As String
    Public Property Type As ParticleType
    Public Property Family As ParticleFamily
    Public Property Generation As Generation
    Public Property Mass As Double ' in MeV/c² or GeV/c²
    Public Property ElectricCharge As Double ' in units of e
    Public Property Spin As Double ' in units of ħ
    Public Property IsFermion As Boolean
    Public Property IsBoson As Boolean
    Public Property BaryonNumber As Integer
    Public Property LeptonNumber As Integer
    Public Property Strangeness As Integer
    Public Property Charm As Integer
    Public Property Bottomness As Integer
    Public Property Topness As Integer
    Public Property MeanLifetime As String
    Public Property DiscoveryYear As Integer
    Public Property AntiparticleName As String
    Public Property ColorCharge As String
    Public Property WeakIsospin As Double
    Public Property WeakHypercharge As Double
    
    Public Sub New()
        BaryonNumber = 0
        LeptonNumber = 0
        Strangeness = 0
        Charm = 0
        Bottomness = 0
        Topness = 0
        ColorCharge = "None"
    End Sub
    
    Public Overrides Function ToString() As String
        Return String.Format("{0} ({1})", Name, If(IsFermion, "Fermion", "Boson"))
    End Function
End Class

' Main particle physics class
Public Class ParticlePhysics
    Private particles As New List(Of Particle)
    
    Public Sub New()
        InitializeParticles()
    End Sub
    
    Private Sub InitializeParticles()
        ' ========================================
        ' FERMIONS (Spin-1/2 particles)
        ' ========================================
        
        ' === QUARKS (Generation 1) ===
        particles.Add(New Particle With {
            .Name = "Up Quark",
            .Type = ParticleType.UpQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.First,
            .Mass = 2.3, ' MeV/c²
            .ElectricCharge = 2.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .ColorCharge = "RGB",
            .WeakIsospin = 0.5,
            .WeakHypercharge = 1.0/3.0,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1968,
            .AntiparticleName = "Anti-up Quark"
        })
        
        particles.Add(New Particle With {
            .Name = "Down Quark",
            .Type = ParticleType.DownQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.First,
            .Mass = 4.8, ' MeV/c²
            .ElectricCharge = -1.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .ColorCharge = "RGB",
            .WeakIsospin = -0.5,
            .WeakHypercharge = 1.0/3.0,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1968,
            .AntiparticleName = "Anti-down Quark"
        })
        
        ' === QUARKS (Generation 2) ===
        particles.Add(New Particle With {
            .Name = "Charm Quark",
            .Type = ParticleType.CharmQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.Second,
            .Mass = 1275, ' MeV/c²
            .ElectricCharge = 2.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .Charm = 1,
            .ColorCharge = "RGB",
            .MeanLifetime = "1.1 × 10⁻¹² s",
            .DiscoveryYear = 1974,
            .AntiparticleName = "Anti-charm Quark"
        })
        
        particles.Add(New Particle With {
            .Name = "Strange Quark",
            .Type = ParticleType.StrangeQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.Second,
            .Mass = 95, ' MeV/c²
            .ElectricCharge = -1.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .Strangeness = -1,
            .ColorCharge = "RGB",
            .MeanLifetime = "1.2 × 10⁻⁸ s",
            .DiscoveryYear = 1947,
            .AntiparticleName = "Anti-strange Quark"
        })
        
        ' === QUARKS (Generation 3) ===
        particles.Add(New Particle With {
            .Name = "Top Quark",
            .Type = ParticleType.TopQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.Third,
            .Mass = 173000, ' MeV/c² (173 GeV/c²)
            .ElectricCharge = 2.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .Topness = 1,
            .ColorCharge = "RGB",
            .MeanLifetime = "5 × 10⁻²⁵ s",
            .DiscoveryYear = 1995,
            .AntiparticleName = "Anti-top Quark"
        })
        
        particles.Add(New Particle With {
            .Name = "Bottom Quark",
            .Type = ParticleType.BottomQuark,
            .Family = ParticleFamily.Quark,
            .Generation = Generation.Third,
            .Mass = 4180, ' MeV/c² (4.18 GeV/c²)
            .ElectricCharge = -1.0/3.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .BaryonNumber = 1,
            .Bottomness = -1,
            .ColorCharge = "RGB",
            .MeanLifetime = "1.5 × 10⁻¹² s",
            .DiscoveryYear = 1977,
            .AntiparticleName = "Anti-bottom Quark"
        })
        
        ' === LEPTONS (Generation 1) ===
        particles.Add(New Particle With {
            .Name = "Electron",
            .Type = ParticleType.Electron,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.First,
            .Mass = 0.511, ' MeV/c²
            .ElectricCharge = -1.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "Stable (> 6.6 × 10²⁸ years)",
            .DiscoveryYear = 1897,
            .AntiparticleName = "Positron"
        })
        
        particles.Add(New Particle With {
            .Name = "Electron Neutrino",
            .Type = ParticleType.ElectronNeutrino,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.First,
            .Mass = 0.0000001, ' < 0.12 eV/c²
            .ElectricCharge = 0.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1956,
            .AntiparticleName = "Electron Antineutrino"
        })
        
        ' === LEPTONS (Generation 2) ===
        particles.Add(New Particle With {
            .Name = "Muon",
            .Type = ParticleType.Muon,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.Second,
            .Mass = 105.7, ' MeV/c²
            .ElectricCharge = -1.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "2.2 × 10⁻⁶ s",
            .DiscoveryYear = 1936,
            .AntiparticleName = "Anti-muon"
        })
        
        particles.Add(New Particle With {
            .Name = "Muon Neutrino",
            .Type = ParticleType.MuonNeutrino,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.Second,
            .Mass = 0.0000001, ' < 0.12 eV/c²
            .ElectricCharge = 0.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1962,
            .AntiparticleName = "Muon Antineutrino"
        })
        
        ' === LEPTONS (Generation 3) ===
        particles.Add(New Particle With {
            .Name = "Tau",
            .Type = ParticleType.Tau,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.Third,
            .Mass = 1776.9, ' MeV/c²
            .ElectricCharge = -1.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "2.9 × 10⁻¹³ s",
            .DiscoveryYear = 1975,
            .AntiparticleName = "Anti-tau"
        })
        
        particles.Add(New Particle With {
            .Name = "Tau Neutrino",
            .Type = ParticleType.TauNeutrino,
            .Family = ParticleFamily.Lepton,
            .Generation = Generation.Third,
            .Mass = 0.0000001, ' < 0.12 eV/c²
            .ElectricCharge = 0.0,
            .Spin = 0.5,
            .IsFermion = True,
            .IsBoson = False,
            .LeptonNumber = 1,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 2000,
            .AntiparticleName = "Tau Antineutrino"
        })
        
        ' ========================================
        ' BOSONS (Force Carriers)
        ' ========================================
        
        ' === GAUGE BOSONS (Spin-1) ===
        particles.Add(New Particle With {
            .Name = "Photon",
            .Type = ParticleType.Photon,
            .Family = ParticleFamily.GaugeBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 0.0,
            .ElectricCharge = 0.0,
            .Spin = 1.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1905,
            .AntiparticleName = "Same (self-conjugate)"
        })
        
        particles.Add(New Particle With {
            .Name = "Gluon",
            .Type = ParticleType.Gluon,
            .Family = ParticleFamily.GaugeBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 0.0,
            .ElectricCharge = 0.0,
            .Spin = 1.0,
            .IsFermion = False,
            .IsBoson = True,
            .ColorCharge = "Color-anticolor (8 types)",
            .MeanLifetime = "Stable",
            .DiscoveryYear = 1979,
            .AntiparticleName = "Same (self-conjugate)"
        })
        
        particles.Add(New Particle With {
            .Name = "W+ Boson",
            .Type = ParticleType.WPlusBoson,
            .Family = ParticleFamily.GaugeBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 80379, ' MeV/c² (80.379 GeV/c²)
            .ElectricCharge = 1.0,
            .Spin = 1.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "3 × 10⁻²⁵ s",
            .DiscoveryYear = 1983,
            .AntiparticleName = "W- Boson"
        })
        
        particles.Add(New Particle With {
            .Name = "W- Boson",
            .Type = ParticleType.WMinusBoson,
            .Family = ParticleFamily.GaugeBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 80379, ' MeV/c²
            .ElectricCharge = -1.0,
            .Spin = 1.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "3 × 10⁻²⁵ s",
            .DiscoveryYear = 1983,
            .AntiparticleName = "W+ Boson"
        })
        
        particles.Add(New Particle With {
            .Name = "Z Boson",
            .Type = ParticleType.ZBoson,
            .Family = ParticleFamily.GaugeBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 91187, ' MeV/c² (91.187 GeV/c²)
            .ElectricCharge = 0.0,
            .Spin = 1.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "3 × 10⁻²⁵ s",
            .DiscoveryYear = 1983,
            .AntiparticleName = "Same (self-conjugate)"
        })
        
        ' === SCALAR BOSONS (Spin-0) ===
        particles.Add(New Particle With {
            .Name = "Higgs Boson",
            .Type = ParticleType.HiggsBoson,
            .Family = ParticleFamily.ScalarBoson,
            .Generation = Generation.NotApplicable,
            .Mass = 125100, ' MeV/c² (125.1 GeV/c²)
            .ElectricCharge = 0.0,
            .Spin = 0.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "1.6 × 10⁻²² s",
            .DiscoveryYear = 2012,
            .AntiparticleName = "Same (self-conjugate)"
        })
        
        ' === HYPOTHETICAL PARTICLES ===
        particles.Add(New Particle With {
            .Name = "Graviton",
            .Type = ParticleType.Graviton,
            .Family = ParticleFamily.Hypothetical,
            .Generation = Generation.NotApplicable,
            .Mass = 0.0,
            .ElectricCharge = 0.0,
            .Spin = 2.0,
            .IsFermion = False,
            .IsBoson = True,
            .MeanLifetime = "Stable (theoretical)",
            .DiscoveryYear = 0, ' Not yet discovered
            .AntiparticleName = "Same (self-conjugate)"
        })
    End Sub
    
    ' Get all particles
    Public Function GetAllParticles() As List(Of Particle)
        Return particles
    End Function
    
    ' Get particles by family
    Public Function GetParticlesByFamily(family As ParticleFamily) As List(Of Particle)
        Return particles.FindAll(Function(p) p.Family = family)
    End Function
    
    ' Get fermions only
    Public Function GetFermions() As List(Of Particle)
        Return particles.FindAll(Function(p) p.IsFermion)
    End Function
    
    ' Get bosons only
    Public Function GetBosons() As List(Of Particle)
        Return particles.FindAll(Function(p) p.IsBoson)
    End Function
    
    ' Get particles by generation
    Public Function GetParticlesByGeneration(gen As Generation) As List(Of Particle)
        Return particles.FindAll(Function(p) p.Generation = gen)
    End Function
    
    ' Search particle by name
    Public Function SearchParticle(name As String) As List(Of Particle)
        Return particles.FindAll(Function(p) p.Name.ToLower().Contains(name.ToLower()))
    End Function
End Class

' Display formatter class
Public Class ParticleDisplay
    Public Shared Sub PrintParticleDetails(particle As Particle)
        Console.WriteLine("╔" & New String("═", 50) & "╗")
        Console.WriteLine("║ {0,-48} ║", particle.Name)
        Console.WriteLine("╠" & New String("═", 50) & "╣")
        
        Console.WriteLine("║ Type: {0,-42} ║", If(particle.IsFermion, "Fermion", "Boson"))
        Console.WriteLine("║ Family: {0,-41} ║", particle.Family.ToString())
        
        If particle.Generation <> Generation.NotApplicable Then
            Console.WriteLine("║ Generation: {0,-37} ║", particle.Generation.ToString())
        End If
        
        ' Mass display
        Dim massStr As String
        If particle.Mass >= 1000 Then
            massStr = String.Format("{0:F1} GeV/c² ({1:F0} MeV/c²)", particle.Mass/1000, particle.Mass)
        ElseIf particle.Mass > 0 Then
            massStr = String.Format("{0:F3} MeV/c²", particle.Mass)
        Else
            massStr = "0 (massless)"
        End If
        Console.WriteLine("║ Mass: {0,-42} ║", massStr)
        
        ' Charge display
        Dim chargeStr As String
        If Math.Abs(particle.ElectricCharge - 2.0/3.0) < 0.001 Then
            chargeStr = "+2/3 e"
        ElseIf Math.Abs(particle.ElectricCharge - 1.0/3.0) < 0.001 Then
            chargeStr = "+1/3 e"
        ElseIf Math.Abs(particle.ElectricCharge + 1.0/3.0) < 0.001 Then
            chargeStr = "-1/3 e"
        ElseIf Math.Abs(particle.ElectricCharge + 2.0/3.0) < 0.001 Then
            chargeStr = "-2/3 e"
        Else
            chargeStr = String.Format("{0:F1} e", particle.ElectricCharge)
        End If
        Console.WriteLine("║ Electric Charge: {0,-31} ║", chargeStr)
        
        Console.WriteLine("║ Spin: {0,-43} ║", particle.Spin.ToString() & " ħ")
        Console.WriteLine("║ Mean Lifetime: {0,-34} ║", particle.MeanLifetime)
        
        If particle.ColorCharge <> "None" Then
            Console.WriteLine("║ Color Charge: {0,-35} ║", particle.ColorCharge)
        End If
        
        If particle.BaryonNumber <> 0 Then
            Console.WriteLine("║ Baryon Number: {0,-34} ║", particle.BaryonNumber.ToString() & "/3")
        End If
        
        If particle.LeptonNumber <> 0 Then
            Console.WriteLine("║ Lepton Number: {0,-34} ║", particle.LeptonNumber)
        End If
        
        If particle.Strangeness <> 0 Then
            Console.WriteLine("║ Strangeness: {0,-36} ║", particle.Strangeness)
        End If
        
        If particle.Charm <> 0 Then
            Console.WriteLine("║ Charm: {0,-42} ║", particle.Charm)
        End If
        
        If particle.Bottomness <> 0 Then
            Console.WriteLine("║ Bottomness: {0,-38} ║", particle.Bottomness)
        End If
        
        If particle.Topness <> 0 Then
            Console.WriteLine("║ Topness: {0,-41} ║", particle.Topness)
        End If
        
        Console.WriteLine("║ Discovery Year: {0,-34} ║", If(particle.DiscoveryYear > 0, particle.DiscoveryYear.ToString(), "Not yet discovered"))
        Console.WriteLine("║ Antiparticle: {0,-35} ║", particle.AntiparticleName)
        
        Console.WriteLine("╚" & New String("═", 50) & "╝")
        Console.WriteLine()
    End Sub
    
    Public Shared Sub PrintSummary(particles As List(Of Particle))
        Console.WriteLine("┌" & New String("─", 80) & "┐")
        Console.WriteLine("│ {0,-78} │", "PARTICLE PHYSICS - STANDARD MODEL PARTICLES")
        Console.WriteLine("├" & New String("─", 80) & "┤")
        
        ' Count particles by type
        Dim fermions = particles.FindAll(Function(p) p.IsFermion).Count
        Dim bosons = particles.FindAll(Function(p) p.IsBoson).Count
        Dim quarks = particles.FindAll(Function(p) p.Family = ParticleFamily.Quark).Count
        Dim leptons = particles.FindAll(Function(p) p.Family = ParticleFamily.Lepton).Count
        Dim gaugeBosons = particles.FindAll(Function(p) p.Family = ParticleFamily.GaugeBoson).Count
        
        Console.WriteLine("│ {0,-78} │", String.Format("Total particles: {0}", particles.Count))
        Console.WriteLine("│ {0,-78} │", String.Format("  • Fermions: {0} (Quarks: {1}, Leptons: {2})", fermions, quarks, leptons))
        Console.WriteLine("│ {0,-78} │", String.Format("  • Bosons: {0} (Gauge Bosons: {1})", bosons, gaugeBosons))
        
        Console.WriteLine("├" & New String("─", 80) & "┤")
        Console.WriteLine("│ {0,-78} │", "PARTICLE FAMILIES:")
        
        ' List all particles
        For Each family In [Enum].GetValues(GetType(ParticleFamily))
            Dim familyParticles = particles.FindAll(Function(p) p.Family = family)
            If familyParticles.Count > 0 Then
                Console.WriteLine("│ {0,-78} │", String.Format("  {0}:", family.ToString()))
                For Each p In familyParticles
                    Dim typeStr = If(p.IsFermion, "F", "B")
                    Dim massStr = If(p.Mass >= 1000, String.Format("{0:F1} GeV", p.Mass/1000), 
                                    If(p.Mass > 0, String.Format("{0:F1} MeV", p.Mass), "massless"))
                    Console.WriteLine("│ {0,-78} │", String.Format("    • {0,-20} ({1}) - Mass: {2,-12} - Spin: {3}ħ", 
                                      p.Name, typeStr, massStr, p.Spin))
                Next
            End If
        Next
        
        Console.WriteLine("└" & New String("─", 80) & "┘")
    End Sub
End Class

' Main program
Module Program
    Sub Main()
        Console.OutputEncoding = System.Text.Encoding.UTF8
        
        Dim physics As New ParticlePhysics()
        Dim allParticles = physics.GetAllParticles()
        
        ' Display summary
        ParticleDisplay.PrintSummary(allParticles)
        
        Console.WriteLine(vbCrLf & "Press any key to view detailed particle information...")
        Console.ReadKey()
        Console.Clear()
        
        ' Display detailed information for each particle
        For Each particle In allParticles
            ParticleDisplay.PrintParticleDetails(particle)
            Console.WriteLine("Press any key to continue...")
            Console.ReadKey()
            Console.Clear()
        Next
        
        ' Example queries
        Console.WriteLine("EXAMPLE QUERIES:")
        Console.WriteLine("================")
        
        ' Get all fermions
        Console.WriteLine(vbCrLf & "FERMIONS (Spin-1/2 particles):")
        Dim fermions = physics.GetFermions()
        For Each f In fermions
            Console.WriteLine($"  • {f.Name}")
        Next
        
        ' Get all bosons
        Console.WriteLine(vbCrLf & "BOSONS (Force carriers):")
        Dim bosons = physics.GetBosons()
        For Each b In bosons
            Console.WriteLine($"  • {b.Name}")
        Next
        
        ' Get particles by generation
        Console.WriteLine(vbCrLf & "FIRST GENERATION PARTICLES:")
        Dim firstGen = physics.GetParticlesByGeneration(Generation.First)
        For Each p In firstGen
            Console.WriteLine($"  • {p.Name}")
        Next
        
        Console.WriteLine(vbCrLf & "Press any key to exit...")
        Console.ReadKey()
    End Sub
    
End Module