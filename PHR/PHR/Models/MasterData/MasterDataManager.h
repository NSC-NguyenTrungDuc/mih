//
//  MasterDataManager.h
//  PHR
//
//  Created by Luong Le Hoang on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MDBase.h"

typedef NS_ENUM(NSInteger, MasterDataType) {
    
    MasterDataTypeHeightBoy = 0,
    MasterDataTypeHeightGirl = 1,
    MasterDataTypeWeightBoy = 2,
    MasterDataTypeWeightGirl = 3,
    MasterDataTypeBmiBoy = 4,
    MasterDataTypeBmiGirl = 5,
    MasterDataTypeBloodBoy = 6,
    MasterDataTypeBloodGirl = 7,
    MasterDataTypeBodyfat = 8,
    MasterDataTypeHeartrateBoy = 9,
    MasterDataTypeHeartrateGirl = 10,
    MasterDataTypeSleep = 11,
    MasterDataTypeStepBoy = 12,
    MasterDataTypeStepGirl = 13,
    MasterDataTypeTemperature = 14,
    MasterDataTypeNone = 15
};

typedef NS_ENUM(NSInteger, MasterDataRate) {
    MasterDataRateNormal = 0,
    MasterDataRateWarning = 1,
    MasterDataRateSerious = 2
};

@interface MasterDataManager : NSObject

+ (void)processData;
// rate blood pressure
+ (MasterDataRate)rateBloodPressureLow:(double)low high:(double)high isMen:(BOOL)isMen age:(int)age;
// rate blood pressure
+ (MasterDataRate)rateTemperature:(double)temp;
// rate data except blood pressure
+ (MasterDataRate)rateData:(double)data isMen:(BOOL)isMen withType:(MasterDataType)type age:(int)age;
// Suggest time sleep
+ (float)suggestTimeSleepForAge:(int)age isMen:(BOOL)isMen;

+ (double)getMeanData:(BOOL)isMen withType:(MasterDataType)type age:(int)age;
+ (CGPoint)getMinMaxData:(BOOL)isMen withType:(MasterDataType)type age:(int)age;
+ (CGPoint)getMeanDataBloodPressure:(BOOL)isMen withType:(MasterDataType)type age:(int)age;
+ (CGPoint)getMeanAndSdData:(BOOL)isMen withType:(MasterDataType)type age:(int)age;
+ (NSMutableArray*)getMeanDataForBodyFat:(BOOL)isMen age:(int)age;
+ (NSMutableArray*)getMeanDataForTemperature:(int)age;
+ (NSMutableArray*)getMeanDataForBloodPressure:(BOOL) isMen age:(int)age;
+ (NSMutableArray*)getMeanDataForBMIAndWeight:(BOOL) isMen withType:(MasterDataType)type age:(int)age;
@end
