export interface SalvageValueGetDto {
    id: number;
    isActive:Boolean;
    name: string;
    localName: string;
    value: string;
    createdById: string;
    
}
export interface SalvageValuePostDto {
    name: string;
    localName: string;
    value: string;
    createdById: string;
}