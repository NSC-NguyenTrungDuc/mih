//
//  FacebookProfile.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/20/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@class FacebookProfile;
@interface FacebookProfile : NSObject

@property (nonatomic, strong) NSString *token;
@property (nonatomic, strong) NSString *facebookID;
@property (nonatomic, strong) NSString *email;
@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSString *gender;
@property (nonatomic, strong) NSDate *birthday;
@property (nonatomic, strong) NSString *profileImageURL;
- (NSString*)stringBirthdayParam;
- (NSString*)stringGenderParam;

@end


