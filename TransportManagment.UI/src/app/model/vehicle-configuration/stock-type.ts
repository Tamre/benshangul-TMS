export interface StockTypeGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    code: string;
    category: string;
    createdById: string;
    
}
export interface StockTypePostDto {
    //id: number;
    name: string;
    localName: string;
    code: string;
    category: string;
    createdById: string;
    isActive:Boolean;
}