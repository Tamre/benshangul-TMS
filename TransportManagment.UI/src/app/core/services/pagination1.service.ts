import { Injectable } from '@angular/core';
import { MetaData } from 'src/app/model/common';

@Injectable({
  providedIn: 'root'
})
export class Pagination1Service {
  metaData: MetaData | null = null;

  changePage<T>(paginatedResponse: { data: T[], metaData: MetaData }, metaData: MetaData) {
    this.metaData = metaData;
    const allData = paginatedResponse.data;
  
    if (Array.isArray(allData)) {
      const { currentPage, pageSize, totalCount } = metaData;
      const startIndex = (currentPage - 1) * pageSize + 1;
      const endIndex = Math.min(currentPage * pageSize, totalCount);
  
      return allData.slice(startIndex - 1, endIndex);
    } else {
      return [];
    }
  }
}
