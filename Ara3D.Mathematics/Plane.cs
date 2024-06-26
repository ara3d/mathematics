namespace Ara3D.Mathematics
{
    /// <summary>
    /// A structure encapsulating a 3D Plane
    /// </summary>
    public partial struct Plane : ITransformable<Plane>
    {
        public Plane(float x, float y, float z, float d)
            : this(new Vector3(x, y, z), d)
        { }

        public Plane(Vector4 v)
            : this(v.X, v.Y, v.Z, v.W)
        { }

        /// <summary>
        /// Creates a Plane that contains the three given points.
        /// </summary>
        public static Plane CreateFromVertices(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            var a = point2 - point1;
            var b = point3 - point1;
            var n = a.Cross(b);
            var d = -n.Normalize().Dot(point1);
            return new Plane(n.Normalize(), d);
        }

        /// <summary>
        /// Creates a Plane with the given normal that contains the point
        /// </summary>
        public static Plane CreateFromNormalAndPoint(Vector3 normal, Vector3 point)
        {
            var n = normal.Normalize();
            var d = n.Dot(point);

            return new Plane(n, d);
        }

        /// <summary>
        /// Creates a new Plane whose normal vector is the source Plane's normal vector normalized.
        /// </summary>
        /// <param name="value">The source Plane.</param>
        public Plane Normalize()
        {
            const float FLT_EPSILON = 1.192092896e-07f; // smallest such that 1.0+FLT_EPSILON != 1.0
            var normalLengthSquared = Normal.LengthSquared();
            if ((normalLengthSquared - 1.0f).Abs() < FLT_EPSILON)
            {
                // It already normalized, so we don't need to farther process.
                return this;
            }
            var normalLength = normalLengthSquared.Sqrt();
            return new Plane(
                Normal / normalLength,
                D / normalLength);
        }

        /// <summary>
        /// Transforms a normalized Plane by a Matrix.
        /// </summary>
        public Plane Transform(Matrix4x4 matrix)
        {
            Matrix4x4.Invert(matrix, out var m);
            float x = Normal.X, y = Normal.Y, z = Normal.Z, w = D;
            return new Plane(
                x * m.M11 + y * m.M12 + z * m.M13 + w * m.M14,
                x * m.M21 + y * m.M22 + z * m.M23 + w * m.M24,
                x * m.M31 + y * m.M32 + z * m.M33 + w * m.M34,
                x * m.M41 + y * m.M42 + z * m.M43 + w * m.M44);
        }

        /// <summary>
        ///  Transforms a normalized Plane by a Quaternion rotation.
        /// </summary>
        public Plane Transform(Quaternion rotation)
        {
            // Compute rotation matrix.
            var x2 = rotation.X + rotation.X;
            var y2 = rotation.Y + rotation.Y;
            var z2 = rotation.Z + rotation.Z;

            var wx2 = rotation.W * x2;
            var wy2 = rotation.W * y2;
            var wz2 = rotation.W * z2;
            var xx2 = rotation.X * x2;
            var xy2 = rotation.X * y2;
            var xz2 = rotation.X * z2;
            var yy2 = rotation.Y * y2;
            var yz2 = rotation.Y * z2;
            var zz2 = rotation.Z * z2;

            var m11 = 1.0f - yy2 - zz2;
            var m21 = xy2 - wz2;
            var m31 = xz2 + wy2;

            var m12 = xy2 + wz2;
            var m22 = 1.0f - xx2 - zz2;
            var m32 = yz2 - wx2;

            var m13 = xz2 - wy2;
            var m23 = yz2 + wx2;
            var m33 = 1.0f - xx2 - yy2;

            float x = Normal.X, y = Normal.Y, z = Normal.Z;

            return new Plane(
                x * m11 + y * m21 + z * m31,
                x * m12 + y * m22 + z * m32,
                x * m13 + y * m23 + z * m33,
                D);
        }

        /// <summary>
        /// Projects a point onto the plane
        /// </summary>
        public static Vector3 ProjectPointOntoPlane(Plane plane, Vector3 point)
        {
            var dist = point.Dot(plane.Normal) - plane.D;
            return point - plane.Normal * dist;
        }

        /// <summary>
        /// Calculates the dot product of a Plane and Vector4.
        /// </summary>
        public float Dot(Vector4 value)
            => ToVector4().Dot(value);

        /// <summary>
        /// Returns the dot product of a specified Vector3 and the normal vector of this Plane plus the distance (D) value of the Plane.
        /// </summary>
        public float DotCoordinate(Vector3 value)
            => DotNormal(value) + D;

        /// <summary>
        /// Returns the dot product of a specified Vector3 and the Normal vector of this Plane.
        /// </summary>
        public float DotNormal(Vector3 value)
            => Normal.Dot(value);

        /// <summary>
        /// Returns a value less than zero if the points is below the plane, above zero if above the plane, or zero if coplanar
        /// </summary>
        /// <param name="point"></param>
        public float ClassifyPoint(Vector3 point)
            => point.Dot(Normal) + D;

        /// <summary>
        /// Returns a Vector4 representation of the Plane
        /// </summary>
        public Vector4 ToVector4()
            => new Vector4(Normal.X, Normal.Y, Normal.Z, D);
    }
}
