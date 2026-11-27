# Distributed Nash Equilibrium Search Algorithms — Bachelor's Thesis (2022)

Bachelor's qualification work, Taras Shevchenko National University of Kyiv, Faculty of Computer Science and Cybernetics, Department of Computational Mathematics. Specialty 113 Applied Mathematics. Kyiv, 2022.

- **Author:** Denys Piven (4th year, group OM-4)
- **Supervisor:** Prof. Volodymyr Semenov, Dr. Sc. (Phys.-Math.)
- **Language of the thesis:** Ukrainian

## Abstract

The thesis studies distributed algorithms for finding Nash equilibria in network and aggregative games. Three distributed algorithms are formulated, implemented and tested numerically:

1. Continuous-time dynamics
2. A linearly convergent algorithm for networked aggregative games
3. A proximal-point based algorithm for locally coupled network games with unknown parameters (distributed learning)

Continues the 3rd-year coursework [Nash-Equilibrium-Coursework-2021](https://github.com/DenysPiven/Nash-Equilibrium-Coursework-2021).

## Contents

```
thesis/
  Distributed_Nash_equilibrium_search_algorithms.pdf   thesis text
  presentation.pdf                                     defense slides
  figures/                                             plots used in the thesis
src/WindowsFormsApp1/                                  numerical experiments (C#, WinForms)
```

## Code

`src/WindowsFormsApp1` is the program from the thesis appendix: a Windows Forms app that runs the three algorithms on N = 10 players and plots the average strategy over iterations. `Init` draws random starting strategies, then `Algorithm 1/2/3` draw each curve. The code is kept exactly as it appears in the appendix.

Build and run on Windows (Visual Studio 2022 or the .NET SDK with .NET Framework 4.8):

```
dotnet run --project src/WindowsFormsApp1
```

Press `Init` first, then the algorithm buttons.
