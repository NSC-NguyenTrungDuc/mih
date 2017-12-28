//
//  WeightModel.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface WeightModel : NSObject
@property (nonatomic, strong) NSString *weightID;
@property (nonatomic) float weight;
@property (nonatomic, strong) NSString *date;
- (id)initWithWeight:(float)weight date:(NSString*)date;
- (void)updateWithDictionary:(NSDictionary*)data;
+ (instancetype)initWeightWithObj:(NSDictionary *)objWeight;
@end
