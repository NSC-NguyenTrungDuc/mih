//
//  BabyTimeLineModel.h
//  PHR
//
//  Created by DEV-MinhNN on 11/16/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>
#import "BabyGrowthWeightModel.h"

@protocol BabyTimeLineModel
@end

@interface BabyTimeLineModel : JSONModel

@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSMutableArray<Optional, BabyMilkModel> *list_baby_milk;
@property (nonatomic, strong) NSMutableArray<Optional, BabyFoodModel> *list_baby_food;
@property (nonatomic, strong) NSMutableArray<Optional, BabyDiaperModel> *list_baby_diaper;
@property (nonatomic, strong) NSMutableArray<Optional, BabyMedicineModel> *list_medicine;
@property (nonatomic, strong) NSMutableArray<Optional, BabyGrowthModel> *list_baby_growth_height;
@property (nonatomic, strong) NSMutableArray<Optional, BabyGrowthModel> *list_baby_growth_weight;
@property (nonatomic, strong) NSMutableArray<Optional, BabySleepModel> *list_baby_sleep;

@end
