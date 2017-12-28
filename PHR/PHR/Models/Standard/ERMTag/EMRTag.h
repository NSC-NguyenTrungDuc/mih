//
//  ERMTag.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/27/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface EMRTag : NSObject

@property (nonatomic, strong) NSString *tagCode;
@property (nonatomic, strong) NSString *tagName;

+ (instancetype)initWithObj:(NSDictionary *)obj;
- (void)updateWithDictionary:(NSDictionary*)data;


@end
