
namespace DomainUnitTest
{
    public class CategoryTests
    {
        [Fact]
        public void ShouldThrowInvalidCategoryNameExceptionGivenNullName()
        {
            FluentActions.Invoking(() => new Category(null, ""))
                .Should().Throw<InvalidCategoryNameException>();
        }
        [Fact]
        public void ShouldThrowInvalidCategoryNameExceptionGivenEmptyName()
        {
            FluentActions.Invoking(() => new Category("",""))
                .Should().Throw<InvalidCategoryNameException>();
        }
        [Fact]
        public void ShouldThrowUnsupportedCategoryNameExceptionGivenWrongName()
        {
            FluentActions.Invoking(() => new Category("WrongName", ""))
                .Should().Throw<UnsupportedCategoryNameException>();
        }
        [Fact]
        public void ShouldThrowUnsupportedSubcategoryNameExceptionGivenNullSubcategoryName()
        {
            FluentActions.Invoking(() => new Category("Business", null))
                .Should().Throw<UnsupportedSubcategoryNameException>();
        }
        [Fact]
        public void ShouldThrowUnsupportedSubcategoryNameExceptionGivenEmptySubcategoryName()
        {
            FluentActions.Invoking(() => new Category("Business", ""))
                .Should().Throw<UnsupportedSubcategoryNameException>();
        }
        [Fact]
        public void ShouldThrowUnsupportedSubcategoryNameExceptionGivenWrongSubcategoryName()
        {
            FluentActions.Invoking(() => new Category("Business", "WrongSubcategory"))
                .Should().Throw<UnsupportedSubcategoryNameException>();
        }
        [Fact]
        public void ShouldNotThrowExceptionGivenProperNames()
        {
            FluentActions.Invoking(() => new Category("Business", "Boss"))
                .Should().NotThrow();
        }
        [Fact]
        public void ShouldThrowInvalidSubcategoryNameExceptionGivenAnySubcategoryNameForPrivateCategory()
        {
            FluentActions.Invoking(() => new Category("Private", "WrongSubcategory"))
                .Should().Throw<InvalidSubcategoryNameException>();
        }
        [Fact]
        public void ShouldNotThrowAnyExceptionGivenNullSubcategoryNameForPrivateCategory()
        {
            FluentActions.Invoking(() => new Category("Private", null))
                .Should().NotThrow();
        }
        [Fact]
        public void ShouldNotThrowAnyExceptionGivenEmptySubcategoryNameForPrivateCategory()
        {
            FluentActions.Invoking(() => new Category("Private", ""))
                .Should().NotThrow();
        }
        [Fact]
        public void ShouldNotThrowAnyExceptionGivenEmptySubcategoryNameForOtherCategory()
        {
            FluentActions.Invoking(() => new Category("Other", "EnySubCategory"))
                .Should().NotThrow();
        }
    }
}