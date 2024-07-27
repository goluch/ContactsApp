export interface Category {
    id: number;
    categoryName: string;
    subcategoryName: string;
}
export interface Contact {
    forename: string;
    surname: string;
    email: string;
    password: string;
    category: Category;
    phoneNumber: string;
    birthDate: Date;
}