//
//  BMIModel.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface BMIModel : NSObject

@property (nonatomic, strong) NSString *bmiID;
@property (nonatomic) float BMI;
@property (nonatomic, strong) NSString *date;
- (id)initWithBMI:(float)bmi date:(NSString*)date;
+ (instancetype)initBMIWithObj:(NSDictionary *)objBMI;
- (void)updateWithDictionary:(NSDictionary*)data;
@end
