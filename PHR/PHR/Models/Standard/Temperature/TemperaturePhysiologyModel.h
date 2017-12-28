//
//  TemperaturePhysiologyModel.h
//  PHR
//
//  Created by BillyMobile on 6/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TemperaturePhysiologyModel : NSObject

@property (nonatomic, strong) NSString *TemperaturePhysiologyID;
@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *note;

@property (nonatomic, strong) NSString *temperature;
@property (nonatomic, strong) NSString *respiratory;
@property (nonatomic, strong) NSString *heartRate;
@property (nonatomic, strong) NSString *heartRateMax;
@property (nonatomic, strong) NSString *lowBloodPressure;
@property (nonatomic, strong) NSString *highBloodPressure;
@property (nonatomic) int type;

- (id)initWithTemperature:(NSString*)temperature respiratory:(NSString*)respiratory heartRate:(NSString*)heartRate lowBloodPressure:(NSString*)lowBloodPressure highBloodPressure:(NSString*)highBloodPressure type:(int)type date:(NSString*)date note:(NSString*)note;

+ (instancetype)initWithObj:(NSDictionary *)obj;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(PHRTemperatureChartType)type;
- (instancetype)initFromSample:(PHRSample*)sample;
- (NSString*)serverType;
@end

