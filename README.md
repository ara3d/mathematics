### DEPRECATED: This library is being replaced by [https://github.com/ara3d/plato.geometry](Plato.Geometry).

 # Ara3D.Mathematics

[![NuGet Version](https://img.shields.io/nuget/v/Ara3D.Mathematics)](https://www.nuget.org/packages/Ara3D.Mathematics)

**Ara3D.Mathematics** is a portable, safe, and efficient 3D math library written in C# 
targeting .NET Standard 2.0 without any dependencies. 

This is a fork of the Math3D repository at [Vim.Math3D](https://github.com/vimaec/math3d),
which was based on earlier work done at [Ara 3D](https://ara3d.com).

Ara3D.Mathematics is compatible with Unity and has been used in production on many different platforms including Windows, 
Android, iOS, WebGL, and Magic Leap. 

# Motivations

There are a few things that we need to do differently than the Vim.Math3D library, motivating this work. 

1. Extend the number of data-structure and algorithms provided 
1. Support auto-generation of code in other languages; particularly JavaScript, and GLSL. 
1. Provide both single and double precision floating point algorithms throughout 
1. Improve the efficiency of the compiled libraries

# How we will Achieve the Goals

To achieve better performance and cross-language code-generation, the core algorithms and data structure 
are being re-written using [the Plato language](https://github.com/cdiggins/plato). 

Plato is designed to make it easy to express generic mathematical concepts and algorithms
in a manner that is easy to analyze, optimize, and port to different languages and platforms. 

The Plato code will then be cross-compiled back to efficient C#.

# Current Status

This library is a work in progress. For now, the Ara3D.Mathematics surface API is quite similar to 
Vim.Math3D which in turn is similar to System.Numerics and Monogame, which is an open-source rewrite 
of the XNA library. 

The double precision data structures have been temporarily removed, and will be reintroduced once the 
port to Plato is completed . 

# Design Goals

The Ara3D.Mathematics design goals remain mostly the same as the Math3D library:

1. Portability
	* The library must be pure C# 
	* No unsafe code 
	* Fixed binary layout of structs in memory
	* Double and Single precision implementation of most structures 
2. Robustness
	* Functions are well covered by unit tests 
	* Functions are easy to read, understand, and verify
3. Ease of Use and Discoverability
	* Consistent with Microsoft coding styles
	* Consistent API with System.Numerics
	* Can use fluent syntax (object-oriented "dot" notation)
	* No passing of arguments by reference
	* Implicit tuple conversions 
4. Performance 
	* Excellent performance, but not at cost of readability or discoverability

## Related Libraries 

* [Vim.Math3D](https://github.com/vimaec/math3d)
* [System.Numerics](https://referencesource.microsoft.com/#System.Numerics,namespaces)
* [SharpDX Mathematics](https://github.com/sharpdx/SharpDX/tree/master/Source/SharpDX.Mathematics)
* [MonoGame](https://github.com/MonoGame/MonoGame)
* [Math.NET Spatial](https://github.com/mathnet/mathnet-spatial)
* [Math.NET Numerics](https://github.com/mathnet/mathnet-numerics)
* [Unity.Mathematics](https://github.com/Unity-Technologies/Unity.Mathematics)
* [Unity Reference](https://github.com/Unity-Technologies/UnityCsReference/tree/master/Runtime/Export)
* [Abacus](https://github.com/sungiant/abacus)
* [Geometry3Sharp](https://github.com/gradientspace/geometry3Sharp)
* [FNA-XNA](https://github.com/FNA-XNA/FNA/tree/master/src)
* [Stride](https://github.com/stride3d/stride/tree/master/sources/core/Stride.Core.Mathematics)
* [A Vector Type for C# - R Potter via Code Project](https://www.codeproject.com/Articles/17425/A-Vector-Type-for-C)
* [Godot Engine C# Libraries](https://github.com/godotengine/godot/tree/master/modules/mono/glue/GodotSharp/GodotSharp/Core)
* [GeometRi - Simple and lightweight computational geometry library for .Net](https://github.com/RiSearcher/GeometRi.CSharp)
* [Veldrid](https://github.com/mellinoe/veldrid/tree/master/src/Veldrid.Utilities)
