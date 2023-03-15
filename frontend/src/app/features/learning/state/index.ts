import { ActionReducerMap, createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromItems from './reducers/items.reducer';

export const featureName = "learningFeature";

export interface LearningState {
    items: fromItems.ItemsState;
}

export const reducers: ActionReducerMap<LearningState> = {
    items: fromItems.reducer,
};

// 1. Feature selector
const selectFeature = createFeatureSelector<LearningState>(featureName);

// 2. Selector Per Branch
const selectItemsBranch = createSelector(selectFeature, (f) => f.items);

// 3. Helpers
export const { selectAll: selectAllItemsEntitiesArray } = fromItems.adapter.getSelectors(selectItemsBranch);

// 4. Components
// ItemsEntity[] - using the selectItemsEntitiesArray from above

