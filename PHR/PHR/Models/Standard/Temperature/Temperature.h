//
//  Temperature.h
//  PHR
//
//  Created by DEV-MinhNN on 10/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSInteger, PHRTemperatureUnit) {
    PHRTemperatureUnitC = 1,
    PHRTemperatureUnitF = 2
};


@interface Temperature : NSObject{
    
}
@property (nonatomic, strong) NSString *id;
@property (nonatomic, strong) NSString *date_measure;
@property (nonatomic, strong) NSString *temperature;
@property (nonatomic, strong) NSString *note;
@property (nonatomic, assign) PHRTemperatureUnit unit;

+ (PHRTemperatureUnit)unitFromServerString:(NSString*)unit;
+ (NSString*)unitStringFromTemperatureUnit:(PHRTemperatureUnit)unit;
+ (NSString*)unitStringFromServerString:(NSString*)unit;
- (NSString*)unitStringFromTemperatureUnit;
- (NSString*)unitStringFromServerString:(NSString*)unit;
- (NSString*)unitServerString;

@end
