//
//  BluetoothDevice.h
//  PHR
//
//  Created by BillyMobile on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface BluetoothDevice : RLMObject

@property (nonatomic, strong) NSString *deviceID;
@property (nonatomic, strong) NSString *deviceName;
@property (nonatomic, strong) NSString *serviceUUID;
@property (nonatomic, strong) NSString *userActiveID;
@property (nonatomic, assign) BOOL useForBaby;
@property (nonatomic, strong) NSString *userName;
@end
