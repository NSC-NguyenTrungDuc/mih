//
//  StandardFitnessTableViewCell.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"
#import "MasterDataModel.h"


@interface StandardDetailTableViewCell : SWTableViewCell
@property (weak, nonatomic) IBOutlet UIView *viewValue;
@property (weak, nonatomic) IBOutlet UILabel *labelValue;
@property (weak, nonatomic) IBOutlet UILabel *labelDateTime;
@property (weak, nonatomic) IBOutlet UILabel *labelRanking;
- (void) setupUIFitness:(FitnessModel*)model type:(ChartFitnessType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel;
- (void) setupUIBodyMeasurement:(BodyMeasurementModel*)model type:(BodyMeasurementType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel;
- (void) setupUIFood:(FoodItem*)model type:(FoodType)type color:(UIColor*)color;
- (void) setupUIVitals:(TemperaturePhysiologyModel*)model type:(PHRTemperatureChartType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel;
- (void) setupUIBabyMilk:(BabyMilkModel*)model type:(PHRGroupTypeMilk)type color:(UIColor*)color;
- (void) setupUIBabyFood:(ChildrenFoodModel*)model color:(UIColor*)color;
- (void) setupUIBabyGrowth:(BabyGrowth*)model type:(BabyGrowthType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel;
@end
