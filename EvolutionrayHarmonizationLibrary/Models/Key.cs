using EvolutionrayHarmonizationLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionrayHarmonizationLibrary.Models
{
    public class Key
    {
        private static readonly Dictionary<Keys, List<(Pitches, Modifiers)>> keyToSigns = new Dictionary<Keys, List<(Pitches, Modifiers)>>
        {
            { Keys.C, new List<(Pitches, Modifiers)>() { } },
            { Keys.a, new List<(Pitches, Modifiers)>() { } },
            { Keys.Cis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp), (Pitches.E, Modifiers.Sharp), (Pitches.H, Modifiers.Sharp) } },
            { Keys.ais, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp), (Pitches.E, Modifiers.Sharp), (Pitches.H, Modifiers.Sharp) } },
            { Keys.Des, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat), (Pitches.G, Modifiers.Flat) } },
            { Keys.b, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat), (Pitches.G, Modifiers.Flat) } },
            { Keys.D, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp) } },
            { Keys.h, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp) } },
            { Keys.Es, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat) } },
            { Keys.c, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat) } },
            { Keys.E, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp) } },
            { Keys.cis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp) } },
            { Keys.F, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat) } },
            { Keys.d, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat) } },
            { Keys.Fis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp), (Pitches.E, Modifiers.Sharp) } },
            { Keys.dis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp), (Pitches.E, Modifiers.Sharp) } },
            { Keys.Ges, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat), (Pitches.G, Modifiers.Flat), (Pitches.C, Modifiers.Flat) } },
            { Keys.es, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat), (Pitches.G, Modifiers.Flat), (Pitches.C, Modifiers.Flat) } },
            { Keys.G, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp) } },
            { Keys.e, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp) } },
            { Keys.As, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat) } },
            { Keys.f, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat), (Pitches.A, Modifiers.Flat), (Pitches.D, Modifiers.Flat) } },
            { Keys.A, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp) } },
            { Keys.fis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp) } },
            { Keys.B, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat) } },
            { Keys.g, new List<(Pitches, Modifiers)>() { (Pitches.H, Modifiers.Flat), (Pitches.E, Modifiers.Flat) } },
            { Keys.H, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp) } },
            { Keys.gis, new List<(Pitches, Modifiers)>() { (Pitches.F, Modifiers.Sharp), (Pitches.C, Modifiers.Sharp), (Pitches.G, Modifiers.Sharp), (Pitches.D, Modifiers.Sharp), (Pitches.A, Modifiers.Sharp) } },
        };

        public Keys KeyValue { get; set; }
        public List<(Pitches, Modifiers)> KeySigns
        {
            get => keyToSigns[KeyValue];
        }

        public Pitch GetDegree(int degree)
        {
            throw new NotImplementedException();
        }
    }
}
