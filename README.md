### Melodic line harmonization
This repository contains code that allows to create tonal or modal chord voicings for a given melodic line with harmonic functions/chord labels. 
The solution is created using the evolutionary algorithm.

The implementation of the algorithm can be found in the <code>EvolutionrayHarmonizationLibrary/Algorithm</code> folder: 
- <code>ClassicGoalFunction</code> folder contains classes implementing the fitness function, corresponding to the tonal version of the algorithm.
- <code>ModalGoalFunction</code> folder contains classes implementing the fitness function, corresponding to the modal version of the algorithm.
- <code>EvolutionSimulation.cs</code> class contains an implementation of the evolutionary algorithm along with mutation and crossover operators.

Examples of inputs can be found in the files <code>EvolutionaryHarmonization/ModalHarmonizationExamples.cs</code> (examples for the modal version) and <code>EvolutionaryHarmonization/TonalHarmonizationExamples.cs</code> (examples for the tonal version).
The <code>Examples</code> folder contains 3 examples of the algorithm output (in png and mp3 formats) for the tonal version of the algorithm.

#### How to use the project
The code was created using .net 5.0, an example call of creating chord voicings for the chosen inputs is included in the <code>EvolutionaryHarmonization/Program.cs</code> file.

#### License
The license is included in the License.txt file.
