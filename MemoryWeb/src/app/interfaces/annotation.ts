export interface Annotation {
  id?: string;
  tags: string;
  type: string;
  order: number;
  description: string;
  categoryId: string;
  categoryName: string;
  categoryDescription: string;
  filterText?: string;
}
