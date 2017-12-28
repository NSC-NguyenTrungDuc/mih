//
//  FacebookProfile.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/20/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FacebookProfile.h"

@implementation FacebookProfile

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (NSString*)stringBirthdayParam {
    //#if DEBUG
    //    NSAssert(self.birthday != nil, @"Birthday must be not nil");
    //#endif
    return [UIUtils stringDate:self.birthday withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
}

- (NSString*)stringGenderParam{
    if ([[self.gender lowercaseString] isEqualToString:[kLocalizedString(kSignUpFemale) lowercaseString]]) {
        return @"F";
    }
    return @"M";
}

@end
