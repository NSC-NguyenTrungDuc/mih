//
//  PHRNotificationKey.h
//  PHR
//
//  Created by Luong Le Hoang on 11/25/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#ifndef PHRNotificationKey_h
#define PHRNotificationKey_h

// Home screen
static NSString * const kNotifyLongTimeComeBackApp  = @"kNotifyLongTimeComeBackApp";

// Dashboard tabbar
static NSString * const kNotifyDashboardChangeTabbarIndex = @"kNotifyDashboardChangeTabbarIndex";

// profile changed avatar
static NSString * const kNotifyAvatarStandardChanged = @"kNotifyAvatarStandardChanged";
static NSString * const kNotifyAvatarBabyChanged = @"kNotifyAvatarBabyChanged";
static NSString * const kNotifyProfileStandardActiveChanged = @"kNotifyProfileStandardActiveChanged";
static NSString * const kNotifyProfileBabyActiveChanged = @"kNotifyProfileBabyActiveChanged";
static NSString * const kNotifyCloseMenuLeft  = @"kNotifyCloseMenuLeft";

//Add selection
static NSString * const kNotifyAddSelectionItem  = @"AddSelectedItemIndex";
static NSString * const kNotifyBackToDashbroad  = @"kNotifyBackToDashbroad";
//Additional Information Register
static NSString * const kNotifyAdditionalInformation  = @"AdditionalInformationRegister";

// Notify when received data from bluetooth device
static NSString * const kNotifyBluetoothData  = @"kNotifyBluetoothData";
static NSString * const kNotifyHealthkitData  = @"kNotifyHealthkitData";
static NSString * const kNotifyBluetoothDataForBaby  = @"kNotifyBluetoothDataForBaby";

// Notify when received data from bluetooth device
static NSString * const kNotifyBlueScanNewDevice  = @"kNotifyBlueScanNewDevice";
static NSString * const kNotifyBlueDisconnectDevice  = @"kNotifyBlueScanDisconnectDevice";
static NSString * const kNotifyBlueConnectDevice  = @"kNotifyBlueConnectNewDevice";

static NSString *const NOTIFICATION_REFRESH_LIST_NOTIFI = @"NOTIFICATION_REFRESH_LIST_NOTIFI";

#endif /* PHRNotificationKey_h */
