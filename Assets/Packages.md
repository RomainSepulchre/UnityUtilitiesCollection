# Packages

A list of useful unity package

## UGizmo

https://github.com/harumas/UGizmo/tree/main

A library of highly efficient gizmo drawer for unity. Offer more type of gizmo and allow to call them in event function (Update(), LateUpdate(), etc...).

## Unity Atoms

https://github.com/unity-atoms/unity-atoms

Open source library that use scriptable objects to make game code more modular, editable and debuggable. 

> ℹ️ Nice for small project but it gets harder to track event subscriptions as the project grows.

> ⚠️ Use with caution when working with addressables, scriptable objects are duplicated in each bundle and it's hard to maintain deduplication with each update (https://x.com/dnnkeeper/status/1932393399967178828)