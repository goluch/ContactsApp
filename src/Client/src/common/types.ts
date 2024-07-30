
export class CategoryItem {
    categoryName: string
    allowedSubcategories: string

    constructor() {
        this.categoryName = ''
        this.allowedSubcategories = ''
    }
}

export class Category {
    id: number
    categoryItemValue: CategoryItem
    subcategoryName: string

    constructor() {
        this.id = 0
        this.categoryItemValue = new CategoryItem
        this.subcategoryName = ''
    }
}

export class Contact {
    id: number
    forename: string
    surname: string
    email: string
    password: string
    category: Category
    phoneNumber: string
    birthDate: Date

    constructor() {
        this.forename = ''
        this.surname = ''
        this.email = ''
        this.password = ''
        this.category = new Category
        this.phoneNumber = ''
        this.birthDate = new Date
    }
}