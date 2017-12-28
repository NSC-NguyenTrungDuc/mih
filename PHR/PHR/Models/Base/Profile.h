//
//  Person.h
//  PHR
//
//  Created by Luong Le Hoang on 10/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@class Profile;
@protocol ProfileDelegate <NSObject>
- (void)profile:(Profile*)profile updateAvatar:(NSString*)newAvatar;
@end

@interface Profile : NSObject {
    
}
@property (nonatomic, assign) id<ProfileDelegate> delegate;
@property (nonatomic, strong) NSString *profileId;
@property (nonatomic, strong) NSString *email;
@property (nonatomic, strong) NSString *name;
@property (nonatomic, strong) NSString *nameKana;
@property (nonatomic, strong) NSString *avatar;
@property (strong, nonatomic) NSDate *birthday;
@property (strong, nonatomic) NSString *relationship;
@property (strong, nonatomic) NSString *gender;
@property (assign, nonatomic) BOOL isActive;
@property (assign, nonatomic) BOOL isBaby;
@property (assign, nonatomic) int age;
@property (strong, nonatomic) NSString *udid;


- (instancetype)initWithDictionary:(NSDictionary *)data;
- (instancetype)initWithCoder:(NSCoder *)decoder;
- (instancetype)initWithProfile:(Profile*)profile;
- (void)encodeWithCoder:(NSCoder *)encoder;
- (void)updateWithDictionary:(NSDictionary*)data;
- (NSString*)stringBirthdayParam;
- (NSString*)stringGenderParam;
- (BOOL)isMen;
- (BOOL)checkActive;
+ (Profile *)sharedManager;

@end
