//
//  MFResponse.h
//  PHR
//
//  Created by DEV-MinhNN on 11/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@interface MFResponse : JSONModel

@property (nonatomic, strong) NSString<Optional> *message;
@property (nonatomic, strong) NSString<Optional> *status;
@property (nonatomic, strong) NSString<Optional> *content;

+ (MFResponse *)responseObjectWithRequestOperation:(NSDictionary *)operation
                                                   error:(NSError *)error;

@end
