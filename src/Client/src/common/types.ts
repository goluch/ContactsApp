export class Category {
    id: number
    categoryName: string
    subcategoryName: string

    constructor() {
        this.id = 0
        this.categoryName = ''
        this.subcategoryName = ''
    }
}

export class Contact {
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