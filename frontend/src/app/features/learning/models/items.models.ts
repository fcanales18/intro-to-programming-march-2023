/* eslint-disable no-irregular-whitespace */
import { ItemEntity } from "../state/reducers/items.reducer"; 

export type ItemEntityRequestModel = Omit<ItemEntity, 'id'>;