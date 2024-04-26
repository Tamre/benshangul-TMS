export interface DocTypeGetDto {
    id: number;
    isActive:Boolean;
    fileName: string;
    fileExtentions: string;
    isPermanentRequired: Boolean;
    isTemporaryRequired: Boolean;
    createdById: string;
    
}
export interface DocTypePostDto {
    fileName: string;
    fileExtentions: string;
    isPermanentRequired: Boolean;
    isTemporaryRequired: Boolean;
    createdById: string;
    isActive:Boolean;
}