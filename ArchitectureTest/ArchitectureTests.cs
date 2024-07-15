using NetArchTest.Rules;
using static System.Net.Mime.MediaTypeNames;

namespace ArchitectureTest
{
    public class ArchitectureTests
    {
        private const string DomainNamespace = "Domain";
        private const string ApplicationNamespace = "Application";
        private const string InfrastructureNamespace = "Infrastructure";
        private const string WebApiNamespace = "WebApi";

        [Fact]
        public void CoreShouldNotHaveDependencyOnOtherProjects()
        {
            var assembly = typeof(Domain.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
            ApplicationNamespace,
            InfrastructureNamespace,
            WebApiNamespace
        };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void ApplicationShouldHaveDependencyOnOtherProjects()
        {
            var assembly = typeof(Application.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
            InfrastructureNamespace,
            WebApiNamespace
        };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact]
        public void InfrastructureShouldHaveDependencyOnOtherProjects()
        {
            var assembly = typeof(Infrastructure.AssemblyReference).Assembly;
            var otherProjects = new[]
            {
            WebApiNamespace
        };

            var result = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }
    }
}