//
//  Temperature.m
//  PHR
//
//  Created by DEV-MinhNN on 10/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Temperature.h"

@implementation Temperature {
    
}

+ (PHRTemperatureUnit)unitFromServerString:(NSString*)unit{
    if ([unit isEqualToString:KEY_Unit_F]) {
        return PHRTemperatureUnitF;
    }
    return PHRTemperatureUnitC;
}

+ (NSString*)unitStringFromTemperatureUnit:(PHRTemperatureUnit)unit{
    if (unit == PHRTemperatureUnitF) {
        return kLocalizedString(kUnitFahrenheit);
    }
    return kLocalizedString(kUnitCelsius);
}

+ (NSString*)unitStringFromServerString:(NSString*)unit{
    return [Temperature unitStringFromTemperatureUnit:[Temperature unitFromServerString:unit]];
}

- (NSString*)unitStringFromTemperatureUnit{
    return [Temperature unitStringFromTemperatureUnit:self.unit];
}

- (NSString*)unitStringFromServerString:(NSString*)unit{
    self.unit = [Temperature unitFromServerString:unit];
    return [self unitStringFromTemperatureUnit];
}

- (NSString*)unitServerString{
    if (self.unit == PHRTemperatureUnitF) {
        return KEY_Unit_F;
    }
    return KEY_Unit_C;
}

@end
