//
//  HeightModel.h
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface HeightModel : NSObject

@property (nonatomic, strong) NSString *heightID;
@property (nonatomic) float height;
@property (nonatomic, strong) NSString *date;

- (id)initWithHeight:(float)height date:(NSString*)date;
+ (instancetype)initHeightWithObj:(NSDictionary *)objHealth;

- (void)updateWithDictionary:(NSDictionary*)data;
@end
