//
//  BabyTimeLineResponse.h
//  PHR
//
//  Created by DEV-MinhNN on 11/17/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>
#import "BabyMilkModel.h"
#import "BabyFoodModel.h"
#import "BabyDiaperModel.h"
#import "BabyMedicineModel.h"
#import "BabyGrowthModel.h"
#import "BabySleepModel.h"
#import "BabyTimeLineModel.h"

@interface BabyTimeLineResponse : JSONModel

@property (nonatomic, strong) NSString *id;
@property (nonatomic, strong) NSString *active_profile_flg;
@property (nonatomic, strong) NSString *full_name;
@property (nonatomic, strong) NSString *full_name_kana;
@property (nonatomic, strong) NSString *nickname;
@property (nonatomic, strong) NSString<Optional> *picture_profile_url;
@property (nonatomic, strong) NSString *baby_flg;
@property (nonatomic, strong) NSArray <BabyTimeLineModel> *baby_timeline_dates;

@end
