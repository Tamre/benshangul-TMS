export interface InitialPriceGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    price: Float32Array;
    createdById: string;
    
}
export interface InitialPricePostDto {
    name: string;
    localName: string;
    price: Float32Array;
    createdById: string;
}