//
//  FitnessModel.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/17/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
@class PHRSample;
@interface FitnessModel : NSObject

@property (nonatomic, strong) NSString *fitnessID;
@property (nonatomic, strong) NSString *date;
@property (nonatomic, strong) NSString *step;
@property (nonatomic, strong) NSString *walkrun;
@property (nonatomic, strong) NSString *note;
@property (nonatomic) int type;

- (id)initFitnessWithStep:(NSString*)step type:(int)type date:(NSString*)date note:(NSString*)note walkrun:(NSString*)walkrun;
+ (instancetype)initWithObj:(NSDictionary *)obj;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (PHRSample*)sampleFromDict:(NSDictionary*)dict type:(ChartFitnessType)type;
- (instancetype)initFromSample:(PHRSample*)sample;

@end
