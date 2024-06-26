﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Ara3D.Mathematics
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector2 
        : IEquatable< Vector2 >
        , IComparable< Vector2 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        public Vector2((float x, float y) tuple) : this(tuple.x, tuple.y) { }
        public Vector2(float x, float y) { X = x; Y = y; }
        public static Vector2 Create(float x, float y) => new Vector2(x, y);
        public static Vector2 Create((float x, float y) tuple) => new Vector2(tuple);
        public override bool Equals(object obj) => obj is Vector2 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        public override string ToString() => $"Vector2(X = {X}, Y = {Y})";
        public void Deconstruct(out float x, out float y) {x = X; y = Y; }
        public bool Equals(Vector2 x) => X == x.X && Y == x.Y;
        public static bool operator ==(Vector2 x0, Vector2 x1) => x0.Equals(x1);
        public static bool operator !=(Vector2 x0, Vector2 x1) => !x0.Equals(x1);
        public static implicit operator Vector2((float x, float y) tuple) => new Vector2(tuple);
        public static implicit operator (float x, float y)(Vector2 self) => (self.X, self.Y);

        public bool AlmostEquals(Vector2 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance);
        public static Vector2 Zero = new Vector2(default, default);
        public static Vector2 MinValue = new Vector2(float.MinValue, float.MinValue);
        public static Vector2 MaxValue = new Vector2(float.MaxValue, float.MaxValue);
        public Vector2 SetX(float x) => new Vector2(x, Y);
        public Vector2 SetY(float x) => new Vector2(X, x);
        public static Vector2 operator +(Vector2 value1, Vector2 value2) => new Vector2(value1.X + value2.X,value1.Y + value2.Y);
        public static Vector2 operator +(Vector2 value1, float value2) => new Vector2(value1.X + value2,value1.Y + value2);
        public static Vector2 operator +(float value1, Vector2 value2) => new Vector2(value1 + value2.X,value1 + value2.Y);
        public static Vector2 operator -(Vector2 value1, Vector2 value2) => new Vector2(value1.X - value2.X,value1.Y - value2.Y);
        public static Vector2 operator -(Vector2 value1, float value2) => new Vector2(value1.X - value2,value1.Y - value2);
        public static Vector2 operator -(float value1, Vector2 value2) => new Vector2(value1 - value2.X,value1 - value2.Y);
        public static Vector2 operator *(Vector2 value1, Vector2 value2) => new Vector2(value1.X * value2.X,value1.Y * value2.Y);
        public static Vector2 operator *(Vector2 value1, float value2) => new Vector2(value1.X * value2,value1.Y * value2);
        public static Vector2 operator *(float value1, Vector2 value2) => new Vector2(value1 * value2.X,value1 * value2.Y);
        public static Vector2 operator /(Vector2 value1, Vector2 value2) => new Vector2(value1.X / value2.X,value1.Y / value2.Y);
        public static Vector2 operator /(Vector2 value1, float value2) => new Vector2(value1.X / value2,value1.Y / value2);
        public static Vector2 operator /(float value1, Vector2 value2) => new Vector2(value1 / value2.X,value1 / value2.Y);
        public static Vector2 One = new Vector2(1f);
        public static Vector2 UnitX = Zero.SetX(1f);
        public static Vector2 UnitY = Zero.SetY(1f);
        public Vector2(float value) : this(value, value) { }
        public static Vector2 operator -(Vector2 value) => Zero - value;
        public static float Dot(Vector2 value1, Vector2 value2) => value1.X * value2.X + value1.Y * value2.Y;
        public float Dot(Vector2 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (X).Min(Y);
        public float MaxComponent() => (X).Max(Y);
        public float SumComponents() => (X) + (Y);
        public float SumSqrComponents() => (X).Sqr() + (Y).Sqr();
        public float ProductComponents() => (X) * (Y);
        public float GetComponent(int n) => n == 0 ? X:Y;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity();
        public int CompareTo(Vector2 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector3 
        : IEquatable< Vector3 >
        , IComparable< Vector3 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        public Vector3((float x, float y, float z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
        public static Vector3 Create(float x, float y, float z) => new Vector3(x, y, z);
        public static Vector3 Create((float x, float y, float z) tuple) => new Vector3(tuple);
        public override bool Equals(object obj) => obj is Vector3 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        public override string ToString() => $"Vector3(X = {X}, Y = {Y}, Z = {Z})";
        public void Deconstruct(out float x, out float y, out float z) {x = X; y = Y; z = Z; }
        public bool Equals(Vector3 x) => X == x.X && Y == x.Y && Z == x.Z;
        public static bool operator ==(Vector3 x0, Vector3 x1) => x0.Equals(x1);
        public static bool operator !=(Vector3 x0, Vector3 x1) => !x0.Equals(x1);
        public static implicit operator Vector3((float x, float y, float z) tuple) => new Vector3(tuple);
        public static implicit operator (float x, float y, float z)(Vector3 self) => (self.X, self.Y, self.Z);

        public bool AlmostEquals(Vector3 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance);
        public static Vector3 Zero = new Vector3(default, default, default);
        public static Vector3 MinValue = new Vector3(float.MinValue, float.MinValue, float.MinValue);
        public static Vector3 MaxValue = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        public Vector3 SetX(float x) => new Vector3(x, Y, Z);
        public Vector3 SetY(float x) => new Vector3(X, x, Z);
        public Vector3 SetZ(float x) => new Vector3(X, Y, x);
        public static Vector3 operator +(Vector3 value1, Vector3 value2) => new Vector3(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z);
        public static Vector3 operator +(Vector3 value1, float value2) => new Vector3(value1.X + value2,value1.Y + value2,value1.Z + value2);
        public static Vector3 operator +(float value1, Vector3 value2) => new Vector3(value1 + value2.X,value1 + value2.Y,value1 + value2.Z);
        public static Vector3 operator -(Vector3 value1, Vector3 value2) => new Vector3(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z);
        public static Vector3 operator -(Vector3 value1, float value2) => new Vector3(value1.X - value2,value1.Y - value2,value1.Z - value2);
        public static Vector3 operator -(float value1, Vector3 value2) => new Vector3(value1 - value2.X,value1 - value2.Y,value1 - value2.Z);
        public static Vector3 operator *(Vector3 value1, Vector3 value2) => new Vector3(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z);
        public static Vector3 operator *(Vector3 value1, float value2) => new Vector3(value1.X * value2,value1.Y * value2,value1.Z * value2);
        public static Vector3 operator *(float value1, Vector3 value2) => new Vector3(value1 * value2.X,value1 * value2.Y,value1 * value2.Z);
        public static Vector3 operator /(Vector3 value1, Vector3 value2) => new Vector3(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z);
        public static Vector3 operator /(Vector3 value1, float value2) => new Vector3(value1.X / value2,value1.Y / value2,value1.Z / value2);
        public static Vector3 operator /(float value1, Vector3 value2) => new Vector3(value1 / value2.X,value1 / value2.Y,value1 / value2.Z);
        public static Vector3 One = new Vector3(1f);
        public static Vector3 UnitX = Zero.SetX(1f);
        public static Vector3 UnitY = Zero.SetY(1f);
        public static Vector3 UnitZ = Zero.SetZ(1f);
        public Vector3(float value) : this(value, value, value) { }
        public static Vector3 operator -(Vector3 value) => Zero - value;
        public static float Dot(Vector3 value1, Vector3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        public float Dot(Vector3 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (X).Min(Y).Min(Z);
        public float MaxComponent() => (X).Max(Y).Max(Z);
        public float SumComponents() => (X) + (Y) + (Z);
        public float SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr();
        public float ProductComponents() => (X) * (Y) * (Z);
        public float GetComponent(int n) => n == 0 ? X : n == 1 ? Y:Z;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity();
        public int CompareTo(Vector3 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector4 
        : IEquatable< Vector4 >
        , IComparable< Vector4 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        [DataMember]
        public readonly float W;
        public Vector4((float x, float y, float z, float w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        public Vector4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        public static Vector4 Create(float x, float y, float z, float w) => new Vector4(x, y, z, w);
        public static Vector4 Create((float x, float y, float z, float w) tuple) => new Vector4(tuple);
        public override bool Equals(object obj) => obj is Vector4 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        public override string ToString() => $"Vector4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        public void Deconstruct(out float x, out float y, out float z, out float w) {x = X; y = Y; z = Z; w = W; }
        public bool Equals(Vector4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        public static bool operator ==(Vector4 x0, Vector4 x1) => x0.Equals(x1);
        public static bool operator !=(Vector4 x0, Vector4 x1) => !x0.Equals(x1);
        public static implicit operator Vector4((float x, float y, float z, float w) tuple) => new Vector4(tuple);
        public static implicit operator (float x, float y, float z, float w)(Vector4 self) => (self.X, self.Y, self.Z, self.W);

        public bool AlmostEquals(Vector4 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static Vector4 Zero = new Vector4(default, default, default, default);
        public static Vector4 MinValue = new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static Vector4 MaxValue = new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        public Vector4 SetX(float x) => new Vector4(x, Y, Z, W);
        public Vector4 SetY(float x) => new Vector4(X, x, Z, W);
        public Vector4 SetZ(float x) => new Vector4(X, Y, x, W);
        public Vector4 SetW(float x) => new Vector4(X, Y, Z, x);
        public static Vector4 operator +(Vector4 value1, Vector4 value2) => new Vector4(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z,value1.W + value2.W);
        public static Vector4 operator +(Vector4 value1, float value2) => new Vector4(value1.X + value2,value1.Y + value2,value1.Z + value2,value1.W + value2);
        public static Vector4 operator +(float value1, Vector4 value2) => new Vector4(value1 + value2.X,value1 + value2.Y,value1 + value2.Z,value1 + value2.W);
        public static Vector4 operator -(Vector4 value1, Vector4 value2) => new Vector4(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z,value1.W - value2.W);
        public static Vector4 operator -(Vector4 value1, float value2) => new Vector4(value1.X - value2,value1.Y - value2,value1.Z - value2,value1.W - value2);
        public static Vector4 operator -(float value1, Vector4 value2) => new Vector4(value1 - value2.X,value1 - value2.Y,value1 - value2.Z,value1 - value2.W);
        public static Vector4 operator *(Vector4 value1, Vector4 value2) => new Vector4(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z,value1.W * value2.W);
        public static Vector4 operator *(Vector4 value1, float value2) => new Vector4(value1.X * value2,value1.Y * value2,value1.Z * value2,value1.W * value2);
        public static Vector4 operator *(float value1, Vector4 value2) => new Vector4(value1 * value2.X,value1 * value2.Y,value1 * value2.Z,value1 * value2.W);
        public static Vector4 operator /(Vector4 value1, Vector4 value2) => new Vector4(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z,value1.W / value2.W);
        public static Vector4 operator /(Vector4 value1, float value2) => new Vector4(value1.X / value2,value1.Y / value2,value1.Z / value2,value1.W / value2);
        public static Vector4 operator /(float value1, Vector4 value2) => new Vector4(value1 / value2.X,value1 / value2.Y,value1 / value2.Z,value1 / value2.W);
        public static Vector4 One = new Vector4(1f);
        public static Vector4 UnitX = Zero.SetX(1f);
        public static Vector4 UnitY = Zero.SetY(1f);
        public static Vector4 UnitZ = Zero.SetZ(1f);
        public static Vector4 UnitW = Zero.SetW(1f);
        public Vector4(float value) : this(value, value, value, value) { }
        public static Vector4 operator -(Vector4 value) => Zero - value;
        public static float Dot(Vector4 value1, Vector4 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z + value1.W * value2.W;
        public float Dot(Vector4 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance && W.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (X).Min(Y).Min(Z).Min(W);
        public float MaxComponent() => (X).Max(Y).Max(Z).Max(W);
        public float SumComponents() => (X) + (Y) + (Z) + (W);
        public float SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr() + (W).Sqr();
        public float ProductComponents() => (X) * (Y) * (Z) * (W);
        public float GetComponent(int n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z:W;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 4;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN() || W.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity() || W.IsInfinity();
        public int CompareTo(Vector4 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) >= 0;
    }
    
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Plane 
        : IEquatable< Plane >
    {
        [DataMember]
        public readonly Vector3 Normal;
        [DataMember]
        public readonly float D;
        public Plane((Vector3 normal, float d) tuple) : this(tuple.normal, tuple.d) { }
        public Plane(Vector3 normal, float d) { Normal = normal; D = d; }
        public static Plane Create(Vector3 normal, float d) => new Plane(normal, d);
        public static Plane Create((Vector3 normal, float d) tuple) => new Plane(tuple);
        public override bool Equals(object obj) => obj is Plane x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Normal.GetHashCode(), D.GetHashCode());
        public override string ToString() => $"Plane(Normal = {Normal}, D = {D})";
        public void Deconstruct(out Vector3 normal, out float d) {normal = Normal; d = D; }
        public bool Equals(Plane x) => Normal == x.Normal && D == x.D;
        public static bool operator ==(Plane x0, Plane x1) => x0.Equals(x1);
        public static bool operator !=(Plane x0, Plane x1) => !x0.Equals(x1);
        public static implicit operator Plane((Vector3 normal, float d) tuple) => new Plane(tuple);
        public static implicit operator (Vector3 normal, float d)(Plane self) => (self.Normal, self.D);

        public bool AlmostEquals(Plane x, float tolerance = Constants.Tolerance) => Normal.AlmostEquals(x.Normal, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Plane Zero = new Plane(default, default);
        public static Plane MinValue = new Plane(Vector3.MinValue, float.MinValue);
        public static Plane MaxValue = new Plane(Vector3.MaxValue, float.MaxValue);
        public Plane SetNormal(Vector3 x) => new Plane(x, D);
        public Plane SetD(float x) => new Plane(Normal, x);
    }
    
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Quaternion 
        : IEquatable< Quaternion >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        [DataMember]
        public readonly float W;
        public Quaternion((float x, float y, float z, float w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        public Quaternion(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        public static Quaternion Create(float x, float y, float z, float w) => new Quaternion(x, y, z, w);
        public static Quaternion Create((float x, float y, float z, float w) tuple) => new Quaternion(tuple);
        public override bool Equals(object obj) => obj is Quaternion x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        public override string ToString() => $"Quaternion(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        public void Deconstruct(out float x, out float y, out float z, out float w) {x = X; y = Y; z = Z; w = W; }
        public bool Equals(Quaternion x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        public static bool operator ==(Quaternion x0, Quaternion x1) => x0.Equals(x1);
        public static bool operator !=(Quaternion x0, Quaternion x1) => !x0.Equals(x1);
        public static implicit operator Quaternion((float x, float y, float z, float w) tuple) => new Quaternion(tuple);
        public static implicit operator (float x, float y, float z, float w)(Quaternion self) => (self.X, self.Y, self.Z, self.W);

        public bool AlmostEquals(Quaternion x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static Quaternion Zero = new Quaternion(default, default, default, default);
        public static Quaternion MinValue = new Quaternion(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static Quaternion MaxValue = new Quaternion(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        public Quaternion SetX(float x) => new Quaternion(x, Y, Z, W);
        public Quaternion SetY(float x) => new Quaternion(X, x, Z, W);
        public Quaternion SetZ(float x) => new Quaternion(X, Y, x, W);
        public Quaternion SetW(float x) => new Quaternion(X, Y, Z, x);
    }
   
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Interval 
        : IEquatable< Interval >
        , IComparable< Interval >
    {
        [DataMember]
        public readonly float Min;
        [DataMember]
        public readonly float Max;
        public Interval((float min, float max) tuple) : this(tuple.min, tuple.max) { }
        public Interval(float min, float max) { Min = min; Max = max; }
        public static Interval Create(float min, float max) => new Interval(min, max);
        public static Interval Create((float min, float max) tuple) => new Interval(tuple);
        public override bool Equals(object obj) => obj is Interval x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        public override string ToString() => $"Interval(Min = {Min}, Max = {Max})";
        public void Deconstruct(out float min, out float max) {min = Min; max = Max; }
        public bool Equals(Interval x) => Min == x.Min && Max == x.Max;
        public static bool operator ==(Interval x0, Interval x1) => x0.Equals(x1);
        public static bool operator !=(Interval x0, Interval x1) => !x0.Equals(x1);
        public static implicit operator Interval((float min, float max) tuple) => new Interval(tuple);
        public static implicit operator (float min, float max)(Interval self) => (self.Min, self.Max);

        public bool AlmostEquals(Interval x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static Interval Zero = new Interval(default, default);
        public static Interval MinValue = new Interval(float.MinValue, float.MinValue);
        public static Interval MaxValue = new Interval(float.MaxValue, float.MaxValue);
        public Interval SetMin(float x) => new Interval(x, Max);
        public Interval SetMax(float x) => new Interval(Min, x);
        public float Extent => (Max - Min);
        public float Center => Min.Average(Max);   
        public float MagnitudeSquared() => Extent.MagnitudeSquared();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public Interval Merge(Interval other) => new Interval(Min.Min(other.Min), Max.Max(other.Max));
        public Interval Intersection(Interval other) => new Interval(Min.Max(other.Min), Max.Min(other.Max));
        public static Interval operator + (Interval value1, Interval value2) => value1.Merge(value2);
        public static Interval operator - (Interval value1, Interval value2) => value1.Intersection(value2);
        public Interval Merge(float other) => new Interval(Min.Min(other), Max.Max(other));
        public static Interval operator + (Interval value1, float value2) => value1.Merge(value2);
        public static Interval Empty = Create(float.MaxValue, float.MinValue);
        public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        public int CompareTo(Interval x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Interval x0, Interval x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Interval x0, Interval x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Interval x0, Interval x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Interval x0, Interval x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AABox2D 
        : IEquatable< AABox2D >
        , IComparable< AABox2D >
    {
        [DataMember]
        public readonly Vector2 Min;
        [DataMember]
        public readonly Vector2 Max;
        public AABox2D((Vector2 min, Vector2 max) tuple) : this(tuple.min, tuple.max) { }
        public AABox2D(Vector2 min, Vector2 max) { Min = min; Max = max; }
        public static AABox2D Create(Vector2 min, Vector2 max) => new AABox2D(min, max);
        public static AABox2D Create((Vector2 min, Vector2 max) tuple) => new AABox2D(tuple);
        public override bool Equals(object obj) => obj is AABox2D x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        public override string ToString() => $"AABox2D(Min = {Min}, Max = {Max})";
        public void Deconstruct(out Vector2 min, out Vector2 max) {min = Min; max = Max; }
        public bool Equals(AABox2D x) => Min == x.Min && Max == x.Max;
        public static bool operator ==(AABox2D x0, AABox2D x1) => x0.Equals(x1);
        public static bool operator !=(AABox2D x0, AABox2D x1) => !x0.Equals(x1);
        public static implicit operator AABox2D((Vector2 min, Vector2 max) tuple) => new AABox2D(tuple);
        public static implicit operator (Vector2 min, Vector2 max)(AABox2D self) => (self.Min, self.Max);

        public bool AlmostEquals(AABox2D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox2D Zero = new AABox2D(default, default);
        public static AABox2D MinValue = new AABox2D(Vector2.MinValue, Vector2.MinValue);
        public static AABox2D MaxValue = new AABox2D(Vector2.MaxValue, Vector2.MaxValue);
        public AABox2D SetMin(Vector2 x) => new AABox2D(x, Max);
        public AABox2D SetMax(Vector2 x) => new AABox2D(Min, x);
        public Vector2 Extent => (Max - Min);
        public Vector2 Center => Min.Average(Max);   
        public float MagnitudeSquared() => Extent.MagnitudeSquared();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public AABox2D Merge(AABox2D other) => new AABox2D(Min.Min(other.Min), Max.Max(other.Max));
        public AABox2D Intersection(AABox2D other) => new AABox2D(Min.Max(other.Min), Max.Min(other.Max));
        public static AABox2D operator + (AABox2D value1, AABox2D value2) => value1.Merge(value2);
        public static AABox2D operator - (AABox2D value1, AABox2D value2) => value1.Intersection(value2);
        public AABox2D Merge(Vector2 other) => new AABox2D(Min.Min(other), Max.Max(other));
        public static AABox2D operator + (AABox2D value1, Vector2 value2) => value1.Merge(value2);
        public static AABox2D Empty = Create(Vector2.MaxValue, Vector2.MinValue);
        public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        public int CompareTo(AABox2D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AABox 
        : IEquatable< AABox >
        , IComparable< AABox >
    {
        [DataMember]
        public readonly Vector3 Min;
        [DataMember]
        public readonly Vector3 Max;
        public AABox((Vector3 min, Vector3 max) tuple) : this(tuple.min, tuple.max) { }
        public AABox(Vector3 min, Vector3 max) { Min = min; Max = max; }
        public static AABox Create(Vector3 min, Vector3 max) => new AABox(min, max);
        public static AABox Create((Vector3 min, Vector3 max) tuple) => new AABox(tuple);
        public override bool Equals(object obj) => obj is AABox x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        public override string ToString() => $"AABox(Min = {Min}, Max = {Max})";
        public void Deconstruct(out Vector3 min, out Vector3 max) {min = Min; max = Max; }
        public bool Equals(AABox x) => Min == x.Min && Max == x.Max;
        public static bool operator ==(AABox x0, AABox x1) => x0.Equals(x1);
        public static bool operator !=(AABox x0, AABox x1) => !x0.Equals(x1);
        public static implicit operator AABox((Vector3 min, Vector3 max) tuple) => new AABox(tuple);
        public static implicit operator (Vector3 min, Vector3 max)(AABox self) => (self.Min, self.Max);

        public bool AlmostEquals(AABox x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox Zero = new AABox(default, default);
        public static AABox MinValue = new AABox(Vector3.MinValue, Vector3.MinValue);
        public static AABox MaxValue = new AABox(Vector3.MaxValue, Vector3.MaxValue);
        public AABox SetMin(Vector3 x) => new AABox(x, Max);
        public AABox SetMax(Vector3 x) => new AABox(Min, x);
        public Vector3 Extent => (Max - Min);
        public Vector3 Center => Min.Average(Max);   
        public float MagnitudeSquared() => Extent.MagnitudeSquared();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public AABox Merge(AABox other) => new AABox(Min.Min(other.Min), Max.Max(other.Max));
        public AABox Intersection(AABox other) => new AABox(Min.Max(other.Min), Max.Min(other.Max));
        public static AABox operator + (AABox value1, AABox value2) => value1.Merge(value2);
        public static AABox operator - (AABox value1, AABox value2) => value1.Intersection(value2);
        public AABox Merge(Vector3 other) => new AABox(Min.Min(other), Max.Max(other));
        public static AABox operator + (AABox value1, Vector3 value2) => value1.Merge(value2);
        public static AABox Empty = Create(Vector3.MaxValue, Vector3.MinValue);
        public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        public int CompareTo(AABox x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(AABox x0, AABox x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(AABox x0, AABox x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(AABox x0, AABox x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(AABox x0, AABox x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct AABox4D 
        : IEquatable< AABox4D >
        , IComparable< AABox4D >
    {
        [DataMember]
        public readonly Vector4 Min;
        [DataMember]
        public readonly Vector4 Max;
        public AABox4D((Vector4 min, Vector4 max) tuple) : this(tuple.min, tuple.max) { }
        public AABox4D(Vector4 min, Vector4 max) { Min = min; Max = max; }
        public static AABox4D Create(Vector4 min, Vector4 max) => new AABox4D(min, max);
        public static AABox4D Create((Vector4 min, Vector4 max) tuple) => new AABox4D(tuple);
        public override bool Equals(object obj) => obj is AABox4D x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        public override string ToString() => $"AABox4D(Min = {Min}, Max = {Max})";
        public void Deconstruct(out Vector4 min, out Vector4 max) {min = Min; max = Max; }
        public bool Equals(AABox4D x) => Min == x.Min && Max == x.Max;
        public static bool operator ==(AABox4D x0, AABox4D x1) => x0.Equals(x1);
        public static bool operator !=(AABox4D x0, AABox4D x1) => !x0.Equals(x1);
        public static implicit operator AABox4D((Vector4 min, Vector4 max) tuple) => new AABox4D(tuple);
        public static implicit operator (Vector4 min, Vector4 max)(AABox4D self) => (self.Min, self.Max);

        public bool AlmostEquals(AABox4D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox4D Zero = new AABox4D(default, default);
        public static AABox4D MinValue = new AABox4D(Vector4.MinValue, Vector4.MinValue);
        public static AABox4D MaxValue = new AABox4D(Vector4.MaxValue, Vector4.MaxValue);
        public AABox4D SetMin(Vector4 x) => new AABox4D(x, Max);
        public AABox4D SetMax(Vector4 x) => new AABox4D(Min, x);
        public Vector4 Extent => (Max - Min);
        public Vector4 Center => Min.Average(Max);   
        public float MagnitudeSquared() => Extent.MagnitudeSquared();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public AABox4D Merge(AABox4D other) => new AABox4D(Min.Min(other.Min), Max.Max(other.Max));
        public AABox4D Intersection(AABox4D other) => new AABox4D(Min.Max(other.Min), Max.Min(other.Max));
        public static AABox4D operator + (AABox4D value1, AABox4D value2) => value1.Merge(value2);
        public static AABox4D operator - (AABox4D value1, AABox4D value2) => value1.Intersection(value2);
        public AABox4D Merge(Vector4 other) => new AABox4D(Min.Min(other), Max.Max(other));
        public static AABox4D operator + (AABox4D value1, Vector4 value2) => value1.Merge(value2);
        public static AABox4D Empty = Create(Vector4.MaxValue, Vector4.MinValue);
        public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        public int CompareTo(AABox4D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) >= 0;
    }
    
 
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Ray 
        : IEquatable< Ray >
    {
        [DataMember]
        public readonly Vector3 Position;
        [DataMember]
        public readonly Vector3 Direction;
        public Ray((Vector3 position, Vector3 direction) tuple) : this(tuple.position, tuple.direction) { }
        public Ray(Vector3 position, Vector3 direction) { Position = position; Direction = direction; }
        public static Ray Create(Vector3 position, Vector3 direction) => new Ray(position, direction);
        public static Ray Create((Vector3 position, Vector3 direction) tuple) => new Ray(tuple);
        public override bool Equals(object obj) => obj is Ray x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Direction.GetHashCode());
        public override string ToString() => $"Ray(Position = {Position}, Direction = {Direction})";
        public void Deconstruct(out Vector3 position, out Vector3 direction) {position = Position; direction = Direction; }
        public bool Equals(Ray x) => Position == x.Position && Direction == x.Direction;
        public static bool operator ==(Ray x0, Ray x1) => x0.Equals(x1);
        public static bool operator !=(Ray x0, Ray x1) => !x0.Equals(x1);
        public static implicit operator Ray((Vector3 position, Vector3 direction) tuple) => new Ray(tuple);
        public static implicit operator (Vector3 position, Vector3 direction)(Ray self) => (self.Position, self.Direction);

        public bool AlmostEquals(Ray x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Direction.AlmostEquals(x.Direction, tolerance);
        public static Ray Zero = new Ray(default, default);
        public static Ray MinValue = new Ray(Vector3.MinValue, Vector3.MinValue);
        public static Ray MaxValue = new Ray(Vector3.MaxValue, Vector3.MaxValue);
        public Ray SetPosition(Vector3 x) => new Ray(x, Direction);
        public Ray SetDirection(Vector3 x) => new Ray(Position, x);
    }
    
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Sphere 
        : IEquatable< Sphere >
    {
        [DataMember]
        public readonly Vector3 Center;
        [DataMember]
        public readonly float Radius;
        public Sphere((Vector3 center, float radius) tuple) : this(tuple.center, tuple.radius) { }
        public Sphere(Vector3 center, float radius) { Center = center; Radius = radius; }
        public static Sphere Create(Vector3 center, float radius) => new Sphere(center, radius);
        public static Sphere Create((Vector3 center, float radius) tuple) => new Sphere(tuple);
        public override bool Equals(object obj) => obj is Sphere x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Center.GetHashCode(), Radius.GetHashCode());
        public override string ToString() => $"Sphere(Center = {Center}, Radius = {Radius})";
        public void Deconstruct(out Vector3 center, out float radius) {center = Center; radius = Radius; }
        public bool Equals(Sphere x) => Center == x.Center && Radius == x.Radius;
        public static bool operator ==(Sphere x0, Sphere x1) => x0.Equals(x1);
        public static bool operator !=(Sphere x0, Sphere x1) => !x0.Equals(x1);
        public static implicit operator Sphere((Vector3 center, float radius) tuple) => new Sphere(tuple);
        public static implicit operator (Vector3 center, float radius)(Sphere self) => (self.Center, self.Radius);

        public bool AlmostEquals(Sphere x, float tolerance = Constants.Tolerance) => Center.AlmostEquals(x.Center, tolerance) && Radius.AlmostEquals(x.Radius, tolerance);
        public static Sphere Zero = new Sphere(default, default);
        public static Sphere MinValue = new Sphere(Vector3.MinValue, float.MinValue);
        public static Sphere MaxValue = new Sphere(Vector3.MaxValue, float.MaxValue);
        public Sphere SetCenter(Vector3 x) => new Sphere(x, Radius);
        public Sphere SetRadius(float x) => new Sphere(Center, x);
    }
    
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Pose 
        : IEquatable< Pose >
    {
        [DataMember]
        public readonly Vector3 Position;
        [DataMember]
        public readonly Quaternion Orientation;
        public Pose((Vector3 position, Quaternion orientation) tuple) : this(tuple.position, tuple.orientation) { }
        public Pose(Vector3 position, Quaternion orientation) { Position = position; Orientation = orientation; }
        public static Pose Create(Vector3 position, Quaternion orientation) => new Pose(position, orientation);
        public static Pose Create((Vector3 position, Quaternion orientation) tuple) => new Pose(tuple);
        public override bool Equals(object obj) => obj is Pose x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Orientation.GetHashCode());
        public override string ToString() => $"Pose(Position = {Position}, Orientation = {Orientation})";
        public void Deconstruct(out Vector3 position, out Quaternion orientation) {position = Position; orientation = Orientation; }
        public bool Equals(Pose x) => Position == x.Position && Orientation == x.Orientation;
        public static bool operator ==(Pose x0, Pose x1) => x0.Equals(x1);
        public static bool operator !=(Pose x0, Pose x1) => !x0.Equals(x1);
        public static implicit operator Pose((Vector3 position, Quaternion orientation) tuple) => new Pose(tuple);
        public static implicit operator (Vector3 position, Quaternion orientation)(Pose self) => (self.Position, self.Orientation);

        public bool AlmostEquals(Pose x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Orientation.AlmostEquals(x.Orientation, tolerance);
        public static Pose Zero = new Pose(default, default);
        public static Pose MinValue = new Pose(Vector3.MinValue, Quaternion.MinValue);
        public static Pose MaxValue = new Pose(Vector3.MaxValue, Quaternion.MaxValue);
        public Pose SetPosition(Vector3 x) => new Pose(x, Orientation);
        public Pose SetOrientation(Quaternion x) => new Pose(Position, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    [DataContract]
    public readonly partial struct Frame
        : IEquatable<Frame>
    {
        [DataMember]
        public readonly Vector3 Position;
        [DataMember]
        public readonly Vector3 Forward;
        [DataMember]
        public readonly Vector3 Up;
        public Frame((Vector3 position, Vector3 forward, Vector3 up) tuple) : this(tuple.position, tuple.forward, tuple.up) { }
        public Frame(Vector3 position, Vector3 forward, Vector3 up) { Position = position; Forward = forward; Up = up; }
        public static Frame Create(Vector3 position, Vector3 forward, Vector3 up) => new Frame (position, forward, up);
        public static Frame Create((Vector3 position, Vector3 forward, Vector3 up) tuple) => new Frame (tuple);
        public override bool Equals(object obj) => obj is Frame  x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Forward.GetHashCode(), Up.GetHashCode());
        public override string ToString() => $"Frame (Position = {Position}, Forward = {Forward}, Up = {Up})";
        public void Deconstruct(out Vector3 position, out Vector3 forward, out Vector3 up) { position = Position; forward = Forward; up = Up; }
        public bool Equals(Frame  x) => Position == x.Position && Forward == x.Forward && Up == x.Up;
        public static bool operator ==(Frame  x0, Frame  x1) => x0.Equals(x1);
        public static bool operator !=(Frame  x0, Frame  x1) => !x0.Equals(x1);
        public static implicit operator Frame ((Vector3 position, Vector3 forward, Vector3 up) tuple) => new Frame (tuple);
        public static implicit operator (Vector3 position, Vector3 forward, Vector3 up)(Frame  self) => (self.Position, self.Forward, self.Up);

        public bool AlmostEquals(Frame  x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Forward.AlmostEquals(x.Forward, tolerance) && Up.AlmostEquals(x.Up, tolerance);
        public Frame SetPosition(Vector3 x) => new Frame (x, Forward, Up);
        public Frame SetForward(Vector3 x) => new Frame (Position, x, Up);
        public Frame SetUp(Vector3 x) => new Frame(Position, Forward, x);
    }

    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Line 
        : IEquatable< Line >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        public Line((Vector3 a, Vector3 b) tuple) : this(tuple.a, tuple.b) { }
        public Line(Vector3 a, Vector3 b) { A = a; B = b; }
        public static Line Create(Vector3 a, Vector3 b) => new Line(a, b);
        public static Line Create((Vector3 a, Vector3 b) tuple) => new Line(tuple);
        public override bool Equals(object obj) => obj is Line x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode());
        public override string ToString() => $"Line(A = {A}, B = {B})";
        public void Deconstruct(out Vector3 a, out Vector3 b) {a = A; b = B; }
        public bool Equals(Line x) => A == x.A && B == x.B;
        public static bool operator ==(Line x0, Line x1) => x0.Equals(x1);
        public static bool operator !=(Line x0, Line x1) => !x0.Equals(x1);
        public static implicit operator Line((Vector3 a, Vector3 b) tuple) => new Line(tuple);
        public static implicit operator (Vector3 a, Vector3 b)(Line self) => (self.A, self.B);

        public bool AlmostEquals(Line x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance);
        public static Line Zero = new Line(default, default);
        public static Line MinValue = new Line(Vector3.MinValue, Vector3.MinValue);
        public static Line MaxValue = new Line(Vector3.MaxValue, Vector3.MaxValue);
        public Line SetA(Vector3 x) => new Line(x, B);
        public Line SetB(Vector3 x) => new Line(A, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Line2D 
        : IEquatable< Line2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        public Line2D((Vector2 a, Vector2 b) tuple) : this(tuple.a, tuple.b) { }
        public Line2D(Vector2 a, Vector2 b) { A = a; B = b; }
        public static Line2D Create(Vector2 a, Vector2 b) => new Line2D(a, b);
        public static Line2D Create((Vector2 a, Vector2 b) tuple) => new Line2D(tuple);
        public override bool Equals(object obj) => obj is Line2D x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode());
        public override string ToString() => $"Line2D(A = {A}, B = {B})";
        public void Deconstruct(out Vector2 a, out Vector2 b) {a = A; b = B; }
        public bool Equals(Line2D x) => A == x.A && B == x.B;
        public static bool operator ==(Line2D x0, Line2D x1) => x0.Equals(x1);
        public static bool operator !=(Line2D x0, Line2D x1) => !x0.Equals(x1);
        public static implicit operator Line2D((Vector2 a, Vector2 b) tuple) => new Line2D(tuple);
        public static implicit operator (Vector2 a, Vector2 b)(Line2D self) => (self.A, self.B);

        public bool AlmostEquals(Line2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance);
        public static Line2D Zero = new Line2D(default, default);
        public static Line2D MinValue = new Line2D(Vector2.MinValue, Vector2.MinValue);
        public static Line2D MaxValue = new Line2D(Vector2.MaxValue, Vector2.MaxValue);
        public Line2D SetA(Vector2 x) => new Line2D(x, B);
        public Line2D SetB(Vector2 x) => new Line2D(A, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Triangle 
        : IEquatable< Triangle >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        [DataMember]
        public readonly Vector3 C;
        public Triangle((Vector3 a, Vector3 b, Vector3 c) tuple) : this(tuple.a, tuple.b, tuple.c) { }
        public Triangle(Vector3 a, Vector3 b, Vector3 c) { A = a; B = b; C = c; }
        public static Triangle Create(Vector3 a, Vector3 b, Vector3 c) => new Triangle(a, b, c);
        public static Triangle Create((Vector3 a, Vector3 b, Vector3 c) tuple) => new Triangle(tuple);
        public override bool Equals(object obj) => obj is Triangle x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode());
        public override string ToString() => $"Triangle(A = {A}, B = {B}, C = {C})";
        public void Deconstruct(out Vector3 a, out Vector3 b, out Vector3 c) {a = A; b = B; c = C; }
        public bool Equals(Triangle x) => A == x.A && B == x.B && C == x.C;
        public static bool operator ==(Triangle x0, Triangle x1) => x0.Equals(x1);
        public static bool operator !=(Triangle x0, Triangle x1) => !x0.Equals(x1);
        public static implicit operator Triangle((Vector3 a, Vector3 b, Vector3 c) tuple) => new Triangle(tuple);
        public static implicit operator (Vector3 a, Vector3 b, Vector3 c)(Triangle self) => (self.A, self.B, self.C);

        public bool AlmostEquals(Triangle x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance);
        public static Triangle Zero = new Triangle(default, default, default);
        public static Triangle MinValue = new Triangle(Vector3.MinValue, Vector3.MinValue, Vector3.MinValue);
        public static Triangle MaxValue = new Triangle(Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue);
        public Triangle SetA(Vector3 x) => new Triangle(x, B, C);
        public Triangle SetB(Vector3 x) => new Triangle(A, x, C);
        public Triangle SetC(Vector3 x) => new Triangle(A, B, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Triangle2D 
        : IEquatable< Triangle2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        [DataMember]
        public readonly Vector2 C;
        public Triangle2D((Vector2 a, Vector2 b, Vector2 c) tuple) : this(tuple.a, tuple.b, tuple.c) { }
        public Triangle2D(Vector2 a, Vector2 b, Vector2 c) { A = a; B = b; C = c; }
        public static Triangle2D Create(Vector2 a, Vector2 b, Vector2 c) => new Triangle2D(a, b, c);
        public static Triangle2D Create((Vector2 a, Vector2 b, Vector2 c) tuple) => new Triangle2D(tuple);
        public override bool Equals(object obj) => obj is Triangle2D x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode());
        public override string ToString() => $"Triangle2D(A = {A}, B = {B}, C = {C})";
        public void Deconstruct(out Vector2 a, out Vector2 b, out Vector2 c) {a = A; b = B; c = C; }
        public bool Equals(Triangle2D x) => A == x.A && B == x.B && C == x.C;
        public static bool operator ==(Triangle2D x0, Triangle2D x1) => x0.Equals(x1);
        public static bool operator !=(Triangle2D x0, Triangle2D x1) => !x0.Equals(x1);
        public static implicit operator Triangle2D((Vector2 a, Vector2 b, Vector2 c) tuple) => new Triangle2D(tuple);
        public static implicit operator (Vector2 a, Vector2 b, Vector2 c)(Triangle2D self) => (self.A, self.B, self.C);

        public bool AlmostEquals(Triangle2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance);
        public static Triangle2D Zero = new Triangle2D(default, default, default);
        public static Triangle2D MinValue = new Triangle2D(Vector2.MinValue, Vector2.MinValue, Vector2.MinValue);
        public static Triangle2D MaxValue = new Triangle2D(Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue);
        public Triangle2D SetA(Vector2 x) => new Triangle2D(x, B, C);
        public Triangle2D SetB(Vector2 x) => new Triangle2D(A, x, C);
        public Triangle2D SetC(Vector2 x) => new Triangle2D(A, B, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Quad 
        : IEquatable< Quad >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        [DataMember]
        public readonly Vector3 C;
        [DataMember]
        public readonly Vector3 D;
        public Quad((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) : this(tuple.a, tuple.b, tuple.c, tuple.d) { }
        public Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d) { A = a; B = b; C = c; D = d; }
        public static Quad Create(Vector3 a, Vector3 b, Vector3 c, Vector3 d) => new Quad(a, b, c, d);
        public static Quad Create((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) => new Quad(tuple);
        public override bool Equals(object obj) => obj is Quad x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode(), D.GetHashCode());
        public override string ToString() => $"Quad(A = {A}, B = {B}, C = {C}, D = {D})";
        public void Deconstruct(out Vector3 a, out Vector3 b, out Vector3 c, out Vector3 d) {a = A; b = B; c = C; d = D; }
        public bool Equals(Quad x) => A == x.A && B == x.B && C == x.C && D == x.D;
        public static bool operator ==(Quad x0, Quad x1) => x0.Equals(x1);
        public static bool operator !=(Quad x0, Quad x1) => !x0.Equals(x1);
        public static implicit operator Quad((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) => new Quad(tuple);
        public static implicit operator (Vector3 a, Vector3 b, Vector3 c, Vector3 d)(Quad self) => (self.A, self.B, self.C, self.D);

        public bool AlmostEquals(Quad x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Quad Zero = new Quad(default, default, default, default);
        public static Quad MinValue = new Quad(Vector3.MinValue, Vector3.MinValue, Vector3.MinValue, Vector3.MinValue);
        public static Quad MaxValue = new Quad(Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue);
        public Quad SetA(Vector3 x) => new Quad(x, B, C, D);
        public Quad SetB(Vector3 x) => new Quad(A, x, C, D);
        public Quad SetC(Vector3 x) => new Quad(A, B, x, D);
        public Quad SetD(Vector3 x) => new Quad(A, B, C, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct Quad2D 
        : IEquatable< Quad2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        [DataMember]
        public readonly Vector2 C;
        [DataMember]
        public readonly Vector2 D;
        public Quad2D((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) : this(tuple.a, tuple.b, tuple.c, tuple.d) { }
        public Quad2D(Vector2 a, Vector2 b, Vector2 c, Vector2 d) { A = a; B = b; C = c; D = d; }
        public static Quad2D Create(Vector2 a, Vector2 b, Vector2 c, Vector2 d) => new Quad2D(a, b, c, d);
        public static Quad2D Create((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) => new Quad2D(tuple);
        public override bool Equals(object obj) => obj is Quad2D x && Equals(x);
        public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode(), D.GetHashCode());
        public override string ToString() => $"Quad2D(A = {A}, B = {B}, C = {C}, D = {D})";
        public void Deconstruct(out Vector2 a, out Vector2 b, out Vector2 c, out Vector2 d) {a = A; b = B; c = C; d = D; }
        public bool Equals(Quad2D x) => A == x.A && B == x.B && C == x.C && D == x.D;
        public static bool operator ==(Quad2D x0, Quad2D x1) => x0.Equals(x1);
        public static bool operator !=(Quad2D x0, Quad2D x1) => !x0.Equals(x1);
        public static implicit operator Quad2D((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) => new Quad2D(tuple);
        public static implicit operator (Vector2 a, Vector2 b, Vector2 c, Vector2 d)(Quad2D self) => (self.A, self.B, self.C, self.D);

        public bool AlmostEquals(Quad2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Quad2D Zero = new Quad2D(default, default, default, default);
        public static Quad2D MinValue = new Quad2D(Vector2.MinValue, Vector2.MinValue, Vector2.MinValue, Vector2.MinValue);
        public static Quad2D MaxValue = new Quad2D(Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue);
        public Quad2D SetA(Vector2 x) => new Quad2D(x, B, C, D);
        public Quad2D SetB(Vector2 x) => new Quad2D(A, x, C, D);
        public Quad2D SetC(Vector2 x) => new Quad2D(A, B, x, D);
        public Quad2D SetD(Vector2 x) => new Quad2D(A, B, C, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int2 
        : IEquatable< Int2 >
        , IComparable< Int2 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        public Int2((int x, int y) tuple) : this(tuple.x, tuple.y) { }
        public Int2(int x, int y) { X = x; Y = y; }
        public static Int2 Create(int x, int y) => new Int2(x, y);
        public static Int2 Create((int x, int y) tuple) => new Int2(tuple);
        public override bool Equals(object obj) => obj is Int2 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        public override string ToString() => $"Int2(X = {X}, Y = {Y})";
        public void Deconstruct(out int x, out int y) {x = X; y = Y; }
        public bool Equals(Int2 x) => X == x.X && Y == x.Y;
        public static bool operator ==(Int2 x0, Int2 x1) => x0.Equals(x1);
        public static bool operator !=(Int2 x0, Int2 x1) => !x0.Equals(x1);
        public static implicit operator Int2((int x, int y) tuple) => new Int2(tuple);
        public static implicit operator (int x, int y)(Int2 self) => (self.X, self.Y);

        public static Int2 Zero = new Int2(default, default);
        public static Int2 MinValue = new Int2(int.MinValue, int.MinValue);
        public static Int2 MaxValue = new Int2(int.MaxValue, int.MaxValue);
        public Int2 SetX(int x) => new Int2(x, Y);
        public Int2 SetY(int x) => new Int2(X, x);
        public static Int2 operator +(Int2 value1, Int2 value2) => new Int2(value1.X + value2.X,value1.Y + value2.Y);
        public static Int2 operator +(Int2 value1, int value2) => new Int2(value1.X + value2,value1.Y + value2);
        public static Int2 operator +(int value1, Int2 value2) => new Int2(value1 + value2.X,value1 + value2.Y);
        public static Int2 operator -(Int2 value1, Int2 value2) => new Int2(value1.X - value2.X,value1.Y - value2.Y);
        public static Int2 operator -(Int2 value1, int value2) => new Int2(value1.X - value2,value1.Y - value2);
        public static Int2 operator -(int value1, Int2 value2) => new Int2(value1 - value2.X,value1 - value2.Y);
        public static Int2 operator *(Int2 value1, Int2 value2) => new Int2(value1.X * value2.X,value1.Y * value2.Y);
        public static Int2 operator *(Int2 value1, int value2) => new Int2(value1.X * value2,value1.Y * value2);
        public static Int2 operator *(int value1, Int2 value2) => new Int2(value1 * value2.X,value1 * value2.Y);
        public static Int2 operator /(Int2 value1, Int2 value2) => new Int2(value1.X / value2.X,value1.Y / value2.Y);
        public static Int2 operator /(Int2 value1, int value2) => new Int2(value1.X / value2,value1.Y / value2);
        public static Int2 operator /(int value1, Int2 value2) => new Int2(value1 / value2.X,value1 / value2.Y);
        public static Int2 One = new Int2(1);
        public static Int2 UnitX = Zero.SetX(1);
        public static Int2 UnitY = Zero.SetY(1);
        public Int2(int value) : this(value, value) { }
        public static Int2 operator -(Int2 value) => Zero - value;
        public static int Dot(Int2 value1, Int2 value2) => value1.X * value2.X + value1.Y * value2.Y;
        public int Dot(Int2 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public int MinComponent() => (X).Min(Y);
        public int MaxComponent() => (X).Max(Y);
        public int SumComponents() => (X) + (Y);
        public int SumSqrComponents() => (X).Sqr() + (Y).Sqr();
        public int ProductComponents() => (X) * (Y);
        public int GetComponent(int n) => n == 0 ? X:Y;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity();
        public int CompareTo(Int2 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Int2 x0, Int2 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Int2 x0, Int2 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Int2 x0, Int2 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Int2 x0, Int2 x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int3 
        : IEquatable< Int3 >
        , IComparable< Int3 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        [DataMember]
        public readonly int Z;
        public Int3((int x, int y, int z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        public Int3(int x, int y, int z) { X = x; Y = y; Z = z; }
        public static Int3 Create(int x, int y, int z) => new Int3(x, y, z);
        public static Int3 Create((int x, int y, int z) tuple) => new Int3(tuple);
        public override bool Equals(object obj) => obj is Int3 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        public override string ToString() => $"Int3(X = {X}, Y = {Y}, Z = {Z})";
        public void Deconstruct(out int x, out int y, out int z) {x = X; y = Y; z = Z; }
        public bool Equals(Int3 x) => X == x.X && Y == x.Y && Z == x.Z;
        public static bool operator ==(Int3 x0, Int3 x1) => x0.Equals(x1);
        public static bool operator !=(Int3 x0, Int3 x1) => !x0.Equals(x1);
        public static implicit operator Int3((int x, int y, int z) tuple) => new Int3(tuple);
        public static implicit operator (int x, int y, int z)(Int3 self) => (self.X, self.Y, self.Z);

        public static Int3 Zero = new Int3(default, default, default);
        public static Int3 MinValue = new Int3(int.MinValue, int.MinValue, int.MinValue);
        public static Int3 MaxValue = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
        public Int3 SetX(int x) => new Int3(x, Y, Z);
        public Int3 SetY(int x) => new Int3(X, x, Z);
        public Int3 SetZ(int x) => new Int3(X, Y, x);
        public static Int3 operator +(Int3 value1, Int3 value2) => new Int3(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z);
        public static Int3 operator +(Int3 value1, int value2) => new Int3(value1.X + value2,value1.Y + value2,value1.Z + value2);
        public static Int3 operator +(int value1, Int3 value2) => new Int3(value1 + value2.X,value1 + value2.Y,value1 + value2.Z);
        public static Int3 operator -(Int3 value1, Int3 value2) => new Int3(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z);
        public static Int3 operator -(Int3 value1, int value2) => new Int3(value1.X - value2,value1.Y - value2,value1.Z - value2);
        public static Int3 operator -(int value1, Int3 value2) => new Int3(value1 - value2.X,value1 - value2.Y,value1 - value2.Z);
        public static Int3 operator *(Int3 value1, Int3 value2) => new Int3(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z);
        public static Int3 operator *(Int3 value1, int value2) => new Int3(value1.X * value2,value1.Y * value2,value1.Z * value2);
        public static Int3 operator *(int value1, Int3 value2) => new Int3(value1 * value2.X,value1 * value2.Y,value1 * value2.Z);
        public static Int3 operator /(Int3 value1, Int3 value2) => new Int3(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z);
        public static Int3 operator /(Int3 value1, int value2) => new Int3(value1.X / value2,value1.Y / value2,value1.Z / value2);
        public static Int3 operator /(int value1, Int3 value2) => new Int3(value1 / value2.X,value1 / value2.Y,value1 / value2.Z);
        public static Int3 One = new Int3(1);
        public static Int3 UnitX = Zero.SetX(1);
        public static Int3 UnitY = Zero.SetY(1);
        public static Int3 UnitZ = Zero.SetZ(1);
        public Int3(int value) : this(value, value, value) { }
        public static Int3 operator -(Int3 value) => Zero - value;
        public static int Dot(Int3 value1, Int3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        public int Dot(Int3 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public int MinComponent() => (X).Min(Y).Min(Z);
        public int MaxComponent() => (X).Max(Y).Max(Z);
        public int SumComponents() => (X) + (Y) + (Z);
        public int SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr();
        public int ProductComponents() => (X) * (Y) * (Z);
        public int GetComponent(int n) => n == 0 ? X : n == 1 ? Y:Z;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity();
        public int CompareTo(Int3 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Int3 x0, Int3 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Int3 x0, Int3 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Int3 x0, Int3 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Int3 x0, Int3 x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int4 
        : IEquatable< Int4 >
        , IComparable< Int4 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        [DataMember]
        public readonly int Z;
        [DataMember]
        public readonly int W;
        public Int4((int x, int y, int z, int w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        public Int4(int x, int y, int z, int w) { X = x; Y = y; Z = z; W = w; }
        public static Int4 Create(int x, int y, int z, int w) => new Int4(x, y, z, w);
        public static Int4 Create((int x, int y, int z, int w) tuple) => new Int4(tuple);
        public override bool Equals(object obj) => obj is Int4 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        public override string ToString() => $"Int4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        public void Deconstruct(out int x, out int y, out int z, out int w) {x = X; y = Y; z = Z; w = W; }
        public bool Equals(Int4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        public static bool operator ==(Int4 x0, Int4 x1) => x0.Equals(x1);
        public static bool operator !=(Int4 x0, Int4 x1) => !x0.Equals(x1);
        public static implicit operator Int4((int x, int y, int z, int w) tuple) => new Int4(tuple);
        public static implicit operator (int x, int y, int z, int w)(Int4 self) => (self.X, self.Y, self.Z, self.W);

        public static Int4 Zero = new Int4(default, default, default, default);
        public static Int4 MinValue = new Int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
        public static Int4 MaxValue = new Int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
        public Int4 SetX(int x) => new Int4(x, Y, Z, W);
        public Int4 SetY(int x) => new Int4(X, x, Z, W);
        public Int4 SetZ(int x) => new Int4(X, Y, x, W);
        public Int4 SetW(int x) => new Int4(X, Y, Z, x);
        public static Int4 operator +(Int4 value1, Int4 value2) => new Int4(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z,value1.W + value2.W);
        public static Int4 operator +(Int4 value1, int value2) => new Int4(value1.X + value2,value1.Y + value2,value1.Z + value2,value1.W + value2);
        public static Int4 operator +(int value1, Int4 value2) => new Int4(value1 + value2.X,value1 + value2.Y,value1 + value2.Z,value1 + value2.W);
        public static Int4 operator -(Int4 value1, Int4 value2) => new Int4(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z,value1.W - value2.W);
        public static Int4 operator -(Int4 value1, int value2) => new Int4(value1.X - value2,value1.Y - value2,value1.Z - value2,value1.W - value2);
        public static Int4 operator -(int value1, Int4 value2) => new Int4(value1 - value2.X,value1 - value2.Y,value1 - value2.Z,value1 - value2.W);
        public static Int4 operator *(Int4 value1, Int4 value2) => new Int4(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z,value1.W * value2.W);
        public static Int4 operator *(Int4 value1, int value2) => new Int4(value1.X * value2,value1.Y * value2,value1.Z * value2,value1.W * value2);
        public static Int4 operator *(int value1, Int4 value2) => new Int4(value1 * value2.X,value1 * value2.Y,value1 * value2.Z,value1 * value2.W);
        public static Int4 operator /(Int4 value1, Int4 value2) => new Int4(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z,value1.W / value2.W);
        public static Int4 operator /(Int4 value1, int value2) => new Int4(value1.X / value2,value1.Y / value2,value1.Z / value2,value1.W / value2);
        public static Int4 operator /(int value1, Int4 value2) => new Int4(value1 / value2.X,value1 / value2.Y,value1 / value2.Z,value1 / value2.W);
        public static Int4 One = new Int4(1);
        public static Int4 UnitX = Zero.SetX(1);
        public static Int4 UnitY = Zero.SetY(1);
        public static Int4 UnitZ = Zero.SetZ(1);
        public static Int4 UnitW = Zero.SetW(1);
        public Int4(int value) : this(value, value, value, value) { }
        public static Int4 operator -(Int4 value) => Zero - value;
        public static int Dot(Int4 value1, Int4 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z + value1.W * value2.W;
        public int Dot(Int4 value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance && W.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public int MinComponent() => (X).Min(Y).Min(Z).Min(W);
        public int MaxComponent() => (X).Max(Y).Max(Z).Max(W);
        public int SumComponents() => (X) + (Y) + (Z) + (W);
        public int SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr() + (W).Sqr();
        public int ProductComponents() => (X) * (Y) * (Z) * (W);
        public int GetComponent(int n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z:W;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 4;

        public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN() || W.IsNaN();
        public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity() || W.IsInfinity();
        public int CompareTo(Int4 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Int4 x0, Int4 x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Int4 x0, Int4 x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Int4 x0, Int4 x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Int4 x0, Int4 x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct Byte2 
        : IEquatable< Byte2 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        public Byte2((byte x, byte y) tuple) : this(tuple.x, tuple.y) { }
        public Byte2(byte x, byte y) { X = x; Y = y; }
        public static Byte2 Create(byte x, byte y) => new Byte2(x, y);
        public static Byte2 Create((byte x, byte y) tuple) => new Byte2(tuple);
        public override bool Equals(object obj) => obj is Byte2 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        public override string ToString() => $"Byte2(X = {X}, Y = {Y})";
        public void Deconstruct(out byte x, out byte y) {x = X; y = Y; }
        public bool Equals(Byte2 x) => X == x.X && Y == x.Y;
        public static bool operator ==(Byte2 x0, Byte2 x1) => x0.Equals(x1);
        public static bool operator !=(Byte2 x0, Byte2 x1) => !x0.Equals(x1);
        public static implicit operator Byte2((byte x, byte y) tuple) => new Byte2(tuple);
        public static implicit operator (byte x, byte y)(Byte2 self) => (self.X, self.Y);

        public static Byte2 Zero = new Byte2(default, default);
        public static Byte2 MinValue = new Byte2(byte.MinValue, byte.MinValue);
        public static Byte2 MaxValue = new Byte2(byte.MaxValue, byte.MaxValue);
        public Byte2 SetX(byte x) => new Byte2(x, Y);
        public Byte2 SetY(byte x) => new Byte2(X, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct Byte3 
        : IEquatable< Byte3 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        [DataMember]
        public readonly byte Z;
        public Byte3((byte x, byte y, byte z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        public Byte3(byte x, byte y, byte z) { X = x; Y = y; Z = z; }
        public static Byte3 Create(byte x, byte y, byte z) => new Byte3(x, y, z);
        public static Byte3 Create((byte x, byte y, byte z) tuple) => new Byte3(tuple);
        public override bool Equals(object obj) => obj is Byte3 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        public override string ToString() => $"Byte3(X = {X}, Y = {Y}, Z = {Z})";
        public void Deconstruct(out byte x, out byte y, out byte z) {x = X; y = Y; z = Z; }
        public bool Equals(Byte3 x) => X == x.X && Y == x.Y && Z == x.Z;
        public static bool operator ==(Byte3 x0, Byte3 x1) => x0.Equals(x1);
        public static bool operator !=(Byte3 x0, Byte3 x1) => !x0.Equals(x1);
        public static implicit operator Byte3((byte x, byte y, byte z) tuple) => new Byte3(tuple);
        public static implicit operator (byte x, byte y, byte z)(Byte3 self) => (self.X, self.Y, self.Z);

        public static Byte3 Zero = new Byte3(default, default, default);
        public static Byte3 MinValue = new Byte3(byte.MinValue, byte.MinValue, byte.MinValue);
        public static Byte3 MaxValue = new Byte3(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public Byte3 SetX(byte x) => new Byte3(x, Y, Z);
        public Byte3 SetY(byte x) => new Byte3(X, x, Z);
        public Byte3 SetZ(byte x) => new Byte3(X, Y, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct Byte4 
        : IEquatable< Byte4 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        [DataMember]
        public readonly byte Z;
        [DataMember]
        public readonly byte W;
        public Byte4((byte x, byte y, byte z, byte w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        public Byte4(byte x, byte y, byte z, byte w) { X = x; Y = y; Z = z; W = w; }
        public static Byte4 Create(byte x, byte y, byte z, byte w) => new Byte4(x, y, z, w);
        public static Byte4 Create((byte x, byte y, byte z, byte w) tuple) => new Byte4(tuple);
        public override bool Equals(object obj) => obj is Byte4 x && Equals(x);
        public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        public override string ToString() => $"Byte4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        public void Deconstruct(out byte x, out byte y, out byte z, out byte w) {x = X; y = Y; z = Z; w = W; }
        public bool Equals(Byte4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        public static bool operator ==(Byte4 x0, Byte4 x1) => x0.Equals(x1);
        public static bool operator !=(Byte4 x0, Byte4 x1) => !x0.Equals(x1);
        public static implicit operator Byte4((byte x, byte y, byte z, byte w) tuple) => new Byte4(tuple);
        public static implicit operator (byte x, byte y, byte z, byte w)(Byte4 self) => (self.X, self.Y, self.Z, self.W);

        public static Byte4 Zero = new Byte4(default, default, default, default);
        public static Byte4 MinValue = new Byte4(byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue);
        public static Byte4 MaxValue = new Byte4(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public Byte4 SetX(byte x) => new Byte4(x, Y, Z, W);
        public Byte4 SetY(byte x) => new Byte4(X, x, Z, W);
        public Byte4 SetZ(byte x) => new Byte4(X, Y, x, W);
        public Byte4 SetW(byte x) => new Byte4(X, Y, Z, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct ColorRGB 
        : IEquatable< ColorRGB >
    {
        [DataMember]
        public readonly byte R;
        [DataMember]
        public readonly byte G;
        [DataMember]
        public readonly byte B;
        public ColorRGB((byte r, byte g, byte b) tuple) : this(tuple.r, tuple.g, tuple.b) { }
        public ColorRGB(byte r, byte g, byte b) { R = r; G = g; B = b; }
        public static ColorRGB Create(byte r, byte g, byte b) => new ColorRGB(r, g, b);
        public static ColorRGB Create((byte r, byte g, byte b) tuple) => new ColorRGB(tuple);
        public override bool Equals(object obj) => obj is ColorRGB x && Equals(x);
        public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode());
        public override string ToString() => $"ColorRGB(R = {R}, G = {G}, B = {B})";
        public void Deconstruct(out byte r, out byte g, out byte b) {r = R; g = G; b = B; }
        public bool Equals(ColorRGB x) => R == x.R && G == x.G && B == x.B;
        public static bool operator ==(ColorRGB x0, ColorRGB x1) => x0.Equals(x1);
        public static bool operator !=(ColorRGB x0, ColorRGB x1) => !x0.Equals(x1);
        public static implicit operator ColorRGB((byte r, byte g, byte b) tuple) => new ColorRGB(tuple);
        public static implicit operator (byte r, byte g, byte b)(ColorRGB self) => (self.R, self.G, self.B);

        public static ColorRGB Zero = new ColorRGB(default, default, default);
        public static ColorRGB MinValue = new ColorRGB(byte.MinValue, byte.MinValue, byte.MinValue);
        public static ColorRGB MaxValue = new ColorRGB(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public ColorRGB SetR(byte x) => new ColorRGB(x, G, B);
        public ColorRGB SetG(byte x) => new ColorRGB(R, x, B);
        public ColorRGB SetB(byte x) => new ColorRGB(R, G, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct ColorRGBA 
        : IEquatable< ColorRGBA >
    {
        [DataMember]
        public readonly byte R;
        [DataMember]
        public readonly byte G;
        [DataMember]
        public readonly byte B;
        [DataMember]
        public readonly byte A;
        public ColorRGBA((byte r, byte g, byte b, byte a) tuple) : this(tuple.r, tuple.g, tuple.b, tuple.a) { }
        public ColorRGBA(byte r, byte g, byte b, byte a) { R = r; G = g; B = b; A = a; }
        public static ColorRGBA Create(byte r, byte g, byte b, byte a) => new ColorRGBA(r, g, b, a);
        public static ColorRGBA Create((byte r, byte g, byte b, byte a) tuple) => new ColorRGBA(tuple);
        public override bool Equals(object obj) => obj is ColorRGBA x && Equals(x);
        public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode(), A.GetHashCode());
        public override string ToString() => $"ColorRGBA(R = {R}, G = {G}, B = {B}, A = {A})";
        public void Deconstruct(out byte r, out byte g, out byte b, out byte a) {r = R; g = G; b = B; a = A; }
        public bool Equals(ColorRGBA x) => R == x.R && G == x.G && B == x.B && A == x.A;
        public static bool operator ==(ColorRGBA x0, ColorRGBA x1) => x0.Equals(x1);
        public static bool operator !=(ColorRGBA x0, ColorRGBA x1) => !x0.Equals(x1);
        public static implicit operator ColorRGBA((byte r, byte g, byte b, byte a) tuple) => new ColorRGBA(tuple);
        public static implicit operator (byte r, byte g, byte b, byte a)(ColorRGBA self) => (self.R, self.G, self.B, self.A);

        public static ColorRGBA Zero = new ColorRGBA(default, default, default, default);
        public static ColorRGBA MinValue = new ColorRGBA(byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue);
        public static ColorRGBA MaxValue = new ColorRGBA(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        public ColorRGBA SetR(byte x) => new ColorRGBA(x, G, B, A);
        public ColorRGBA SetG(byte x) => new ColorRGBA(R, x, B, A);
        public ColorRGBA SetB(byte x) => new ColorRGBA(R, G, x, A);
        public ColorRGBA SetA(byte x) => new ColorRGBA(R, G, B, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct ColorHDR 
        : IEquatable< ColorHDR >
    {
        [DataMember]
        public readonly float R;
        [DataMember]
        public readonly float G;
        [DataMember]
        public readonly float B;
        [DataMember]
        public readonly float A;
        public ColorHDR((float r, float g, float b, float a) tuple) : this(tuple.r, tuple.g, tuple.b, tuple.a) { }
        public ColorHDR(float r, float g, float b, float a) { R = r; G = g; B = b; A = a; }
        public static ColorHDR Create(float r, float g, float b, float a) => new ColorHDR(r, g, b, a);
        public static ColorHDR Create((float r, float g, float b, float a) tuple) => new ColorHDR(tuple);
        public override bool Equals(object obj) => obj is ColorHDR x && Equals(x);
        public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode(), A.GetHashCode());
        public override string ToString() => $"ColorHDR(R = {R}, G = {G}, B = {B}, A = {A})";
        public void Deconstruct(out float r, out float g, out float b, out float a) {r = R; g = G; b = B; a = A; }
        public bool Equals(ColorHDR x) => R == x.R && G == x.G && B == x.B && A == x.A;
        public static bool operator ==(ColorHDR x0, ColorHDR x1) => x0.Equals(x1);
        public static bool operator !=(ColorHDR x0, ColorHDR x1) => !x0.Equals(x1);
        public static implicit operator ColorHDR((float r, float g, float b, float a) tuple) => new ColorHDR(tuple);
        public static implicit operator (float r, float g, float b, float a)(ColorHDR self) => (self.R, self.G, self.B, self.A);

        public bool AlmostEquals(ColorHDR x, float tolerance = Constants.Tolerance) => R.AlmostEquals(x.R, tolerance) && G.AlmostEquals(x.G, tolerance) && B.AlmostEquals(x.B, tolerance) && A.AlmostEquals(x.A, tolerance);
        public static ColorHDR Zero = new ColorHDR(default, default, default, default);
        public static ColorHDR MinValue = new ColorHDR(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static ColorHDR MaxValue = new ColorHDR(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        public ColorHDR SetR(float x) => new ColorHDR(x, G, B, A);
        public ColorHDR SetG(float x) => new ColorHDR(R, x, B, A);
        public ColorHDR SetB(float x) => new ColorHDR(R, G, x, A);
        public ColorHDR SetA(float x) => new ColorHDR(R, G, B, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct SphericalCoordinate 
        : IEquatable< SphericalCoordinate >
    {
        [DataMember]
        public readonly double Radius;
        [DataMember]
        public readonly double Azimuth;
        [DataMember]
        public readonly double Inclination;
        public SphericalCoordinate((double radius, double azimuth, double inclination) tuple) : this(tuple.radius, tuple.azimuth, tuple.inclination) { }
        public SphericalCoordinate(double radius, double azimuth, double inclination) { Radius = radius; Azimuth = azimuth; Inclination = inclination; }
        public static SphericalCoordinate Create(double radius, double azimuth, double inclination) => new SphericalCoordinate(radius, azimuth, inclination);
        public static SphericalCoordinate Create((double radius, double azimuth, double inclination) tuple) => new SphericalCoordinate(tuple);
        public override bool Equals(object obj) => obj is SphericalCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode(), Inclination.GetHashCode());
        public override string ToString() => $"SphericalCoordinate(Radius = {Radius}, Azimuth = {Azimuth}, Inclination = {Inclination})";
        public void Deconstruct(out double radius, out double azimuth, out double inclination) {radius = Radius; azimuth = Azimuth; inclination = Inclination; }
        public bool Equals(SphericalCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth && Inclination == x.Inclination;
        public static bool operator ==(SphericalCoordinate x0, SphericalCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(SphericalCoordinate x0, SphericalCoordinate x1) => !x0.Equals(x1);
        public static implicit operator SphericalCoordinate((double radius, double azimuth, double inclination) tuple) => new SphericalCoordinate(tuple);
        public static implicit operator (double radius, double azimuth, double inclination)(SphericalCoordinate self) => (self.Radius, self.Azimuth, self.Inclination);

        public bool AlmostEquals(SphericalCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance) && Inclination.AlmostEquals(x.Inclination, tolerance);
        public static SphericalCoordinate Zero = new SphericalCoordinate(default, default, default);
        public static SphericalCoordinate MinValue = new SphericalCoordinate(double.MinValue, double.MinValue, double.MinValue);
        public static SphericalCoordinate MaxValue = new SphericalCoordinate(double.MaxValue, double.MaxValue, double.MaxValue);
        public SphericalCoordinate SetRadius(double x) => new SphericalCoordinate(x, Azimuth, Inclination);
        public SphericalCoordinate SetAzimuth(double x) => new SphericalCoordinate(Radius, x, Inclination);
        public SphericalCoordinate SetInclination(double x) => new SphericalCoordinate(Radius, Azimuth, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct PolarCoordinate 
        : IEquatable< PolarCoordinate >
    {
        [DataMember]
        public readonly float Radius;
        [DataMember]
        public readonly float Azimuth;
        public PolarCoordinate((float radius, float azimuth) tuple) : this(tuple.radius, tuple.azimuth) { }
        public PolarCoordinate(float radius, float azimuth) { Radius = radius; Azimuth = azimuth; }
        public static PolarCoordinate Create(float radius, float azimuth) => new PolarCoordinate(radius, azimuth);
        public static PolarCoordinate Create((float radius, float azimuth) tuple) => new PolarCoordinate(tuple);
        public override bool Equals(object obj) => obj is PolarCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode());
        public override string ToString() => $"PolarCoordinate(Radius = {Radius}, Azimuth = {Azimuth})";
        public void Deconstruct(out float radius, out float azimuth) {radius = Radius; azimuth = Azimuth; }
        public bool Equals(PolarCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth;
        public static bool operator ==(PolarCoordinate x0, PolarCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(PolarCoordinate x0, PolarCoordinate x1) => !x0.Equals(x1);
        public static implicit operator PolarCoordinate((float radius, float azimuth) tuple) => new PolarCoordinate(tuple);
        public static implicit operator (float radius, float azimuth)(PolarCoordinate self) => (self.Radius, self.Azimuth);

        public bool AlmostEquals(PolarCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance);
        public static PolarCoordinate Zero = new PolarCoordinate(default, default);
        public static PolarCoordinate MinValue = new PolarCoordinate(float.MinValue, float.MinValue);
        public static PolarCoordinate MaxValue = new PolarCoordinate(float.MaxValue, float.MaxValue);
        public PolarCoordinate SetRadius(float x) => new PolarCoordinate(x, Azimuth);
        public PolarCoordinate SetAzimuth(float x) => new PolarCoordinate(Radius, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct LogPolarCoordinate 
        : IEquatable< LogPolarCoordinate >
    {
        [DataMember]
        public readonly float Rho;
        [DataMember]
        public readonly float Azimuth;
        public LogPolarCoordinate((float rho, float azimuth) tuple) : this(tuple.rho, tuple.azimuth) { }
        public LogPolarCoordinate(float rho, float azimuth) { Rho = rho; Azimuth = azimuth; }
        public static LogPolarCoordinate Create(float rho, float azimuth) => new LogPolarCoordinate(rho, azimuth);
        public static LogPolarCoordinate Create((float rho, float azimuth) tuple) => new LogPolarCoordinate(tuple);
        public override bool Equals(object obj) => obj is LogPolarCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Rho.GetHashCode(), Azimuth.GetHashCode());
        public override string ToString() => $"LogPolarCoordinate(Rho = {Rho}, Azimuth = {Azimuth})";
        public void Deconstruct(out float rho, out float azimuth) {rho = Rho; azimuth = Azimuth; }
        public bool Equals(LogPolarCoordinate x) => Rho == x.Rho && Azimuth == x.Azimuth;
        public static bool operator ==(LogPolarCoordinate x0, LogPolarCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(LogPolarCoordinate x0, LogPolarCoordinate x1) => !x0.Equals(x1);
        public static implicit operator LogPolarCoordinate((float rho, float azimuth) tuple) => new LogPolarCoordinate(tuple);
        public static implicit operator (float rho, float azimuth)(LogPolarCoordinate self) => (self.Rho, self.Azimuth);

        public bool AlmostEquals(LogPolarCoordinate x, float tolerance = Constants.Tolerance) => Rho.AlmostEquals(x.Rho, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance);
        public static LogPolarCoordinate Zero = new LogPolarCoordinate(default, default);
        public static LogPolarCoordinate MinValue = new LogPolarCoordinate(float.MinValue, float.MinValue);
        public static LogPolarCoordinate MaxValue = new LogPolarCoordinate(float.MaxValue, float.MaxValue);
        public LogPolarCoordinate SetRho(float x) => new LogPolarCoordinate(x, Azimuth);
        public LogPolarCoordinate SetAzimuth(float x) => new LogPolarCoordinate(Rho, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct CylindricalCoordinate 
        : IEquatable< CylindricalCoordinate >
    {
        [DataMember]
        public readonly float Radius;
        [DataMember]
        public readonly float Azimuth;
        [DataMember]
        public readonly float Height;
        public CylindricalCoordinate((float radius, float azimuth, float height) tuple) : this(tuple.radius, tuple.azimuth, tuple.height) { }
        public CylindricalCoordinate(float radius, float azimuth, float height) { Radius = radius; Azimuth = azimuth; Height = height; }
        public static CylindricalCoordinate Create(float radius, float azimuth, float height) => new CylindricalCoordinate(radius, azimuth, height);
        public static CylindricalCoordinate Create((float radius, float azimuth, float height) tuple) => new CylindricalCoordinate(tuple);
        public override bool Equals(object obj) => obj is CylindricalCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode(), Height.GetHashCode());
        public override string ToString() => $"CylindricalCoordinate(Radius = {Radius}, Azimuth = {Azimuth}, Height = {Height})";
        public void Deconstruct(out float radius, out float azimuth, out float height) {radius = Radius; azimuth = Azimuth; height = Height; }
        public bool Equals(CylindricalCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth && Height == x.Height;
        public static bool operator ==(CylindricalCoordinate x0, CylindricalCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(CylindricalCoordinate x0, CylindricalCoordinate x1) => !x0.Equals(x1);
        public static implicit operator CylindricalCoordinate((float radius, float azimuth, float height) tuple) => new CylindricalCoordinate(tuple);
        public static implicit operator (float radius, float azimuth, float height)(CylindricalCoordinate self) => (self.Radius, self.Azimuth, self.Height);

        public bool AlmostEquals(CylindricalCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance) && Height.AlmostEquals(x.Height, tolerance);
        public static CylindricalCoordinate Zero = new CylindricalCoordinate(default, default, default);
        public static CylindricalCoordinate MinValue = new CylindricalCoordinate(float.MinValue, float.MinValue, float.MinValue);
        public static CylindricalCoordinate MaxValue = new CylindricalCoordinate(float.MaxValue, float.MaxValue, float.MaxValue);
        public CylindricalCoordinate SetRadius(float x) => new CylindricalCoordinate(x, Azimuth, Height);
        public CylindricalCoordinate SetAzimuth(float x) => new CylindricalCoordinate(Radius, x, Height);
        public CylindricalCoordinate SetHeight(float x) => new CylindricalCoordinate(Radius, Azimuth, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct HorizontalCoordinate 
        : IEquatable< HorizontalCoordinate >
        , IComparable< HorizontalCoordinate >
    {
        [DataMember]
        public readonly float Azimuth;
        [DataMember]
        public readonly float Inclination;
        public HorizontalCoordinate((float azimuth, float inclination) tuple) : this(tuple.azimuth, tuple.inclination) { }
        public HorizontalCoordinate(float azimuth, float inclination) { Azimuth = azimuth; Inclination = inclination; }
        public static HorizontalCoordinate Create(float azimuth, float inclination) => new HorizontalCoordinate(azimuth, inclination);
        public static HorizontalCoordinate Create((float azimuth, float inclination) tuple) => new HorizontalCoordinate(tuple);
        public override bool Equals(object obj) => obj is HorizontalCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Azimuth.GetHashCode(), Inclination.GetHashCode());
        public override string ToString() => $"HorizontalCoordinate(Azimuth = {Azimuth}, Inclination = {Inclination})";
        public void Deconstruct(out float azimuth, out float inclination) {azimuth = Azimuth; inclination = Inclination; }
        public bool Equals(HorizontalCoordinate x) => Azimuth == x.Azimuth && Inclination == x.Inclination;
        public static bool operator ==(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(HorizontalCoordinate x0, HorizontalCoordinate x1) => !x0.Equals(x1);
        public static implicit operator HorizontalCoordinate((float azimuth, float inclination) tuple) => new HorizontalCoordinate(tuple);
        public static implicit operator (float azimuth, float inclination)(HorizontalCoordinate self) => (self.Azimuth, self.Inclination);

        public bool AlmostEquals(HorizontalCoordinate x, float tolerance = Constants.Tolerance) => Azimuth.AlmostEquals(x.Azimuth, tolerance) && Inclination.AlmostEquals(x.Inclination, tolerance);
        public static HorizontalCoordinate Zero = new HorizontalCoordinate(default, default);
        public static HorizontalCoordinate MinValue = new HorizontalCoordinate(float.MinValue, float.MinValue);
        public static HorizontalCoordinate MaxValue = new HorizontalCoordinate(float.MaxValue, float.MaxValue);
        public HorizontalCoordinate SetAzimuth(float x) => new HorizontalCoordinate(x, Inclination);
        public HorizontalCoordinate SetInclination(float x) => new HorizontalCoordinate(Azimuth, x);
        public static HorizontalCoordinate operator +(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth + value2.Azimuth,value1.Inclination + value2.Inclination);
        public static HorizontalCoordinate operator +(HorizontalCoordinate value1, float value2) => new HorizontalCoordinate(value1.Azimuth + value2,value1.Inclination + value2);
        public static HorizontalCoordinate operator +(float value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 + value2.Azimuth,value1 + value2.Inclination);
        public static HorizontalCoordinate operator -(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth - value2.Azimuth,value1.Inclination - value2.Inclination);
        public static HorizontalCoordinate operator -(HorizontalCoordinate value1, float value2) => new HorizontalCoordinate(value1.Azimuth - value2,value1.Inclination - value2);
        public static HorizontalCoordinate operator -(float value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 - value2.Azimuth,value1 - value2.Inclination);
        public static HorizontalCoordinate operator *(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth * value2.Azimuth,value1.Inclination * value2.Inclination);
        public static HorizontalCoordinate operator *(HorizontalCoordinate value1, float value2) => new HorizontalCoordinate(value1.Azimuth * value2,value1.Inclination * value2);
        public static HorizontalCoordinate operator *(float value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 * value2.Azimuth,value1 * value2.Inclination);
        public static HorizontalCoordinate operator /(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth / value2.Azimuth,value1.Inclination / value2.Inclination);
        public static HorizontalCoordinate operator /(HorizontalCoordinate value1, float value2) => new HorizontalCoordinate(value1.Azimuth / value2,value1.Inclination / value2);
        public static HorizontalCoordinate operator /(float value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 / value2.Azimuth,value1 / value2.Inclination);
        public static HorizontalCoordinate One = new HorizontalCoordinate(1);
        public static HorizontalCoordinate UnitAzimuth = Zero.SetAzimuth(1);
        public static HorizontalCoordinate UnitInclination = Zero.SetInclination(1);
        public HorizontalCoordinate(float value) : this(value, value) { }
        public static HorizontalCoordinate operator -(HorizontalCoordinate value) => Zero - value;
        public static float Dot(HorizontalCoordinate value1, HorizontalCoordinate value2) => value1.Azimuth * value2.Azimuth + value1.Inclination * value2.Inclination;
        public float Dot(HorizontalCoordinate value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => Azimuth.Abs() < tolerance && Inclination.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (Azimuth).Min(Inclination);
        public float MaxComponent() => (Azimuth).Max(Inclination);
        public float SumComponents() => (Azimuth) + (Inclination);
        public float SumSqrComponents() => (Azimuth).Sqr() + (Inclination).Sqr();
        public float ProductComponents() => (Azimuth) * (Inclination);
        public float GetComponent(int n) => n == 0 ? Azimuth:Inclination;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        public bool IsNaN() => Azimuth.IsNaN() || Inclination.IsNaN();
        public bool IsInfinity() => Azimuth.IsInfinity() || Inclination.IsInfinity();
        public int CompareTo(HorizontalCoordinate x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct GeoCoordinate 
        : IEquatable< GeoCoordinate >
        , IComparable< GeoCoordinate >
    {
        [DataMember]
        public readonly float Latitude;
        [DataMember]
        public readonly float Longitude;
        public GeoCoordinate((float latitude, float longitude) tuple) : this(tuple.latitude, tuple.longitude) { }
        public GeoCoordinate(float latitude, float longitude) { Latitude = latitude; Longitude = longitude; }
        public static GeoCoordinate Create(float latitude, float longitude) => new GeoCoordinate(latitude, longitude);
        public static GeoCoordinate Create((float latitude, float longitude) tuple) => new GeoCoordinate(tuple);
        public override bool Equals(object obj) => obj is GeoCoordinate x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Latitude.GetHashCode(), Longitude.GetHashCode());
        public override string ToString() => $"GeoCoordinate(Latitude = {Latitude}, Longitude = {Longitude})";
        public void Deconstruct(out float latitude, out float longitude) {latitude = Latitude; longitude = Longitude; }
        public bool Equals(GeoCoordinate x) => Latitude == x.Latitude && Longitude == x.Longitude;
        public static bool operator ==(GeoCoordinate x0, GeoCoordinate x1) => x0.Equals(x1);
        public static bool operator !=(GeoCoordinate x0, GeoCoordinate x1) => !x0.Equals(x1);
        public static implicit operator GeoCoordinate((float latitude, float longitude) tuple) => new GeoCoordinate(tuple);
        public static implicit operator (float latitude, float longitude)(GeoCoordinate self) => (self.Latitude, self.Longitude);

        public bool AlmostEquals(GeoCoordinate x, float tolerance = Constants.Tolerance) => Latitude.AlmostEquals(x.Latitude, tolerance) && Longitude.AlmostEquals(x.Longitude, tolerance);
        public static GeoCoordinate Zero = new GeoCoordinate(default, default);
        public static GeoCoordinate MinValue = new GeoCoordinate(float.MinValue, float.MinValue);
        public static GeoCoordinate MaxValue = new GeoCoordinate(float.MaxValue, float.MaxValue);
        public GeoCoordinate SetLatitude(float x) => new GeoCoordinate(x, Longitude);
        public GeoCoordinate SetLongitude(float x) => new GeoCoordinate(Latitude, x);
        public static GeoCoordinate operator +(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude + value2.Latitude,value1.Longitude + value2.Longitude);
        public static GeoCoordinate operator +(GeoCoordinate value1, float value2) => new GeoCoordinate(value1.Latitude + value2,value1.Longitude + value2);
        public static GeoCoordinate operator +(float value1, GeoCoordinate value2) => new GeoCoordinate(value1 + value2.Latitude,value1 + value2.Longitude);
        public static GeoCoordinate operator -(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude - value2.Latitude,value1.Longitude - value2.Longitude);
        public static GeoCoordinate operator -(GeoCoordinate value1, float value2) => new GeoCoordinate(value1.Latitude - value2,value1.Longitude - value2);
        public static GeoCoordinate operator -(float value1, GeoCoordinate value2) => new GeoCoordinate(value1 - value2.Latitude,value1 - value2.Longitude);
        public static GeoCoordinate operator *(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude * value2.Latitude,value1.Longitude * value2.Longitude);
        public static GeoCoordinate operator *(GeoCoordinate value1, float value2) => new GeoCoordinate(value1.Latitude * value2,value1.Longitude * value2);
        public static GeoCoordinate operator *(float value1, GeoCoordinate value2) => new GeoCoordinate(value1 * value2.Latitude,value1 * value2.Longitude);
        public static GeoCoordinate operator /(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude / value2.Latitude,value1.Longitude / value2.Longitude);
        public static GeoCoordinate operator /(GeoCoordinate value1, float value2) => new GeoCoordinate(value1.Latitude / value2,value1.Longitude / value2);
        public static GeoCoordinate operator /(float value1, GeoCoordinate value2) => new GeoCoordinate(value1 / value2.Latitude,value1 / value2.Longitude);
        public static GeoCoordinate One = new GeoCoordinate(1);
        public static GeoCoordinate UnitLatitude = Zero.SetLatitude(1);
        public static GeoCoordinate UnitLongitude = Zero.SetLongitude(1);
        public GeoCoordinate(float value) : this(value, value) { }
        public static GeoCoordinate operator -(GeoCoordinate value) => Zero - value;
        public static float Dot(GeoCoordinate value1, GeoCoordinate value2) => value1.Latitude * value2.Latitude + value1.Longitude * value2.Longitude;
        public float Dot(GeoCoordinate value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => Latitude.Abs() < tolerance && Longitude.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (Latitude).Min(Longitude);
        public float MaxComponent() => (Latitude).Max(Longitude);
        public float SumComponents() => (Latitude) + (Longitude);
        public float SumSqrComponents() => (Latitude).Sqr() + (Longitude).Sqr();
        public float ProductComponents() => (Latitude) * (Longitude);
        public float GetComponent(int n) => n == 0 ? Latitude:Longitude;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        public bool IsNaN() => Latitude.IsNaN() || Longitude.IsNaN();
        public bool IsInfinity() => Latitude.IsInfinity() || Longitude.IsInfinity();
        public int CompareTo(GeoCoordinate x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) >= 0;
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct AxisAngle 
        : IEquatable< AxisAngle >
    {
        [DataMember]
        public readonly Vector3 Axis;
        [DataMember]
        public readonly float Angle;
        public AxisAngle((Vector3 axis, float angle) tuple) : this(tuple.axis, tuple.angle) { }
        public AxisAngle(Vector3 axis, float angle) { Axis = axis; Angle = angle; }
        public static AxisAngle Create(Vector3 axis, float angle) => new AxisAngle(axis, angle);
        public static AxisAngle Create((Vector3 axis, float angle) tuple) => new AxisAngle(tuple);
        public override bool Equals(object obj) => obj is AxisAngle x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Axis.GetHashCode(), Angle.GetHashCode());
        public override string ToString() => $"AxisAngle(Axis = {Axis}, Angle = {Angle})";
        public void Deconstruct(out Vector3 axis, out float angle) {axis = Axis; angle = Angle; }
        public bool Equals(AxisAngle x) => Axis == x.Axis && Angle == x.Angle;
        public static bool operator ==(AxisAngle x0, AxisAngle x1) => x0.Equals(x1);
        public static bool operator !=(AxisAngle x0, AxisAngle x1) => !x0.Equals(x1);
        public static implicit operator AxisAngle((Vector3 axis, float angle) tuple) => new AxisAngle(tuple);
        public static implicit operator (Vector3 axis, float angle)(AxisAngle self) => (self.Axis, self.Angle);

        public bool AlmostEquals(AxisAngle x, float tolerance = Constants.Tolerance) => Axis.AlmostEquals(x.Axis, tolerance) && Angle.AlmostEquals(x.Angle, tolerance);
        public static AxisAngle Zero = new AxisAngle(default, default);
        public static AxisAngle MinValue = new AxisAngle(Vector3.MinValue, float.MinValue);
        public static AxisAngle MaxValue = new AxisAngle(Vector3.MaxValue, float.MaxValue);
        public AxisAngle SetAxis(Vector3 x) => new AxisAngle(x, Angle);
        public AxisAngle SetAngle(float x) => new AxisAngle(Axis, x);
    }
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly struct Euler 
        : IEquatable< Euler >
        , IComparable< Euler >
    {
        [DataMember]
        public readonly float Yaw;
        [DataMember]
        public readonly float Pitch;
        [DataMember]
        public readonly float Roll;
        public Euler((float yaw, float pitch, float roll) tuple) : this(tuple.yaw, tuple.pitch, tuple.roll) { }
        public Euler(float yaw, float pitch, float roll) { Yaw = yaw; Pitch = pitch; Roll = roll; }
        public static Euler Create(float yaw, float pitch, float roll) => new Euler(yaw, pitch, roll);
        public static Euler Create((float yaw, float pitch, float roll) tuple) => new Euler(tuple);
        public override bool Equals(object obj) => obj is Euler x && Equals(x);
        public override int GetHashCode() => Hash.Combine(Yaw.GetHashCode(), Pitch.GetHashCode(), Roll.GetHashCode());
        public override string ToString() => $"Euler(Yaw = {Yaw}, Pitch = {Pitch}, Roll = {Roll})";
        public void Deconstruct(out float yaw, out float pitch, out float roll) {yaw = Yaw; pitch = Pitch; roll = Roll; }
        public bool Equals(Euler x) => Yaw == x.Yaw && Pitch == x.Pitch && Roll == x.Roll;
        public static bool operator ==(Euler x0, Euler x1) => x0.Equals(x1);
        public static bool operator !=(Euler x0, Euler x1) => !x0.Equals(x1);
        public static implicit operator Euler((float yaw, float pitch, float roll) tuple) => new Euler(tuple);
        public static implicit operator (float yaw, float pitch, float roll)(Euler self) => (self.Yaw, self.Pitch, self.Roll);

        public bool AlmostEquals(Euler x, float tolerance = Constants.Tolerance) => Yaw.AlmostEquals(x.Yaw, tolerance) && Pitch.AlmostEquals(x.Pitch, tolerance) && Roll.AlmostEquals(x.Roll, tolerance);
        public static Euler Zero = new Euler(default, default, default);
        public static Euler MinValue = new Euler(float.MinValue, float.MinValue, float.MinValue);
        public static Euler MaxValue = new Euler(float.MaxValue, float.MaxValue, float.MaxValue);
        public Euler SetYaw(float x) => new Euler(x, Pitch, Roll);
        public Euler SetPitch(float x) => new Euler(Yaw, x, Roll);
        public Euler SetRoll(float x) => new Euler(Yaw, Pitch, x);
        public static Euler operator +(Euler value1, Euler value2) => new Euler(value1.Yaw + value2.Yaw,value1.Pitch + value2.Pitch,value1.Roll + value2.Roll);
        public static Euler operator +(Euler value1, float value2) => new Euler(value1.Yaw + value2,value1.Pitch + value2,value1.Roll + value2);
        public static Euler operator +(float value1, Euler value2) => new Euler(value1 + value2.Yaw,value1 + value2.Pitch,value1 + value2.Roll);
        public static Euler operator -(Euler value1, Euler value2) => new Euler(value1.Yaw - value2.Yaw,value1.Pitch - value2.Pitch,value1.Roll - value2.Roll);
        public static Euler operator -(Euler value1, float value2) => new Euler(value1.Yaw - value2,value1.Pitch - value2,value1.Roll - value2);
        public static Euler operator -(float value1, Euler value2) => new Euler(value1 - value2.Yaw,value1 - value2.Pitch,value1 - value2.Roll);
        public static Euler operator *(Euler value1, Euler value2) => new Euler(value1.Yaw * value2.Yaw,value1.Pitch * value2.Pitch,value1.Roll * value2.Roll);
        public static Euler operator *(Euler value1, float value2) => new Euler(value1.Yaw * value2,value1.Pitch * value2,value1.Roll * value2);
        public static Euler operator *(float value1, Euler value2) => new Euler(value1 * value2.Yaw,value1 * value2.Pitch,value1 * value2.Roll);
        public static Euler operator /(Euler value1, Euler value2) => new Euler(value1.Yaw / value2.Yaw,value1.Pitch / value2.Pitch,value1.Roll / value2.Roll);
        public static Euler operator /(Euler value1, float value2) => new Euler(value1.Yaw / value2,value1.Pitch / value2,value1.Roll / value2);
        public static Euler operator /(float value1, Euler value2) => new Euler(value1 / value2.Yaw,value1 / value2.Pitch,value1 / value2.Roll);
        public static Euler One = new Euler(1);
        public static Euler UnitYaw = Zero.SetYaw(1);
        public static Euler UnitPitch = Zero.SetPitch(1);
        public static Euler UnitRoll = Zero.SetRoll(1);
        public Euler(float value) : this(value, value, value) { }
        public static Euler operator -(Euler value) => Zero - value;
        public static float Dot(Euler value1, Euler value2) => value1.Yaw * value2.Yaw + value1.Pitch * value2.Pitch + value1.Roll * value2.Roll;
        public float Dot(Euler value) => Dot(this, value);
        public bool AlmostZero(float tolerance = Constants.Tolerance) => Yaw.Abs() < tolerance && Pitch.Abs() < tolerance && Roll.Abs() < tolerance;
        public bool AnyComponentNegative() => MinComponent() < 0;
        public float MinComponent() => (Yaw).Min(Pitch).Min(Roll);
        public float MaxComponent() => (Yaw).Max(Pitch).Max(Roll);
        public float SumComponents() => (Yaw) + (Pitch) + (Roll);
        public float SumSqrComponents() => (Yaw).Sqr() + (Pitch).Sqr() + (Roll).Sqr();
        public float ProductComponents() => (Yaw) * (Pitch) * (Roll);
        public float GetComponent(int n) => n == 0 ? Yaw : n == 1 ? Pitch:Roll;
        public float MagnitudeSquared() => SumSqrComponents();
        public float Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        public bool IsNaN() => Yaw.IsNaN() || Pitch.IsNaN() || Roll.IsNaN();
        public bool IsInfinity() => Yaw.IsInfinity() || Pitch.IsInfinity() || Roll.IsInfinity();
        public int CompareTo(Euler x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        public static bool operator <(Euler x0, Euler x1) => x0.CompareTo(x1) < 0;
        public static bool operator <=(Euler x0, Euler x1) => x0.CompareTo(x1) <= 0;
        public static bool operator >(Euler x0, Euler x1) => x0.CompareTo(x1) > 0;
        public static bool operator >=(Euler x0, Euler x1) => x0.CompareTo(x1) >= 0;
    }
}
