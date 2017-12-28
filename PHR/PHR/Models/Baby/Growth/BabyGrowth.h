//
//  BabyGrowth.h
//  PHR
//
//  Created by DEV-MinhNN on 10/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabyGrowthModel.h"
#import "PHRSample.h"

@interface BabyGrowth : NSObject{
    
}
@property (strong, nonatomic) NSString *growthId; // this id for Height ID
@property (strong, nonatomic) NSString *growthWeightId;
@property (strong, nonatomic) NSString *profileId;
@property (strong, nonatomic) NSString *timeMeasure;
@property (strong, nonatomic) NSString *headSize;
@property (strong, nonatomic) NSString *height;
@property (strong, nonatomic) NSString *weight;
@property (strong, nonatomic) NSString *doctorNote;
@property (strong, nonatomic) NSString *parentNote;
@property (strong, nonatomic) NSString *medicalRecordUrl;
@property (strong, nonatomic) NSString *dateTime;
@property (nonatomic) int type;

+ (instancetype)initBabyGrowthWithObj:(NSDictionary *)objbaby;
+ (BabyGrowth *)initializeBabySleepFromModel:(BabyGrowthModel *)model andDate:(NSString *)date;
- (void)updateWithDictionary:(NSDictionary*)data;
- (void)updateWithDictionaryHeight:(NSDictionary*)data;
- (void)updateWithDictionaryWeight:(NSDictionary*)data;
- (void)updateFromGrowth:(BabyGrowth*)growth;
+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(BabyGrowthType)type;
- (instancetype)initFromSample:(PHRSample*)sample;
- (BabyGrowthModel*)getBabyGrowthModel;
@end
