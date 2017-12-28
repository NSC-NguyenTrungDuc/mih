//
//  ClinicHospital.h
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface ClinicHospital : NSObject{
    
}

@property (nonatomic, strong) NSString *hospitalCode;
@property (nonatomic, strong) NSString *hospitalName;
@property (nonatomic, strong) NSString *address;
@property (nonatomic, strong) NSString *tel;


- (instancetype)initWithDict:(NSDictionary *)dict;

@end
