// <copyright file="MatrixTest.cs" company="HP Inc.">Copyright © HP Inc. 2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TerraTeam3;

namespace TerraTeam3.Tests
{
    /// <summary>This class contains parameterized unit tests for Matrix</summary>
    [PexClass(typeof(Matrix))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MatrixTest
    {
        /// <summary>Test stub for VoegItemToe(MatrixItem)</summary>
        [PexMethod]
        public void VoegItemToeTest([PexAssumeUnderTest]Matrix target, MatrixItem matrixItem)
        {
            target.VoegItemToe(matrixItem);
            // TODO: add assertions to method MatrixTest.VoegItemToeTest(Matrix, MatrixItem)
        }
    }
}
