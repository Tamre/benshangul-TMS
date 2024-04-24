export interface DepCostGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    value: string;
    createdById: string;
    
}
export interface DepCostPostDto {
    name: string;
    localName: string;
    value: string;
    createdById: string;
    isActive:Boolean;
}