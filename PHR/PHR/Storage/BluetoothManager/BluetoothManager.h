//
//  BluetoothManager.h
//  PHR
//
//  Created by BillyMobile on 6/13/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <CoreBluetooth/CoreBluetooth.h>
#import "BluetoothDevice.h"

// Service ID
#define BLEService_BLOOD_PRESSURE @"1810"
#define BLEService_HEART_RATE @"180D"
#define BLEService_BODY_TEMPERATUTE @"1809"
#define BLEService_BODY_COMPOSITION @"181B"
#define BLEService_WEIGHT_SCALE @"181D"


#define BLECharacteristic_HEART_RATE @"2A37"
#define BLECharacteristic_BLOOD_PRESSURE @"2A35"
#define BLECharacteristic_BODY_TEMPERATUTE @"2A1C"
#define BLECharacteristic_Body_Composition @"2A9C"
#define BLECharacteristic_Weight_Scale @"2A9D"



@interface BluetoothManager : NSObject <CBCentralManagerDelegate, CBPeripheralDelegate>{
    
}

@property (nonatomic, strong) CBCentralManager *manager;
@property (nonatomic, strong) CBPeripheral *mainPeripheral;
@property (nonatomic, strong) CBCharacteristic *mainCharacteristic;

@property (nonatomic, strong) RLMResults *allConnectedDevices; // available & invisible
@property (nonatomic, strong) NSMutableArray *availableConnectedDevices; // connected & available
@property (nonatomic, strong) NSMutableArray *scannedDevices; // scan new connected

@property (copy, nonatomic) void (^findDeviceCallBack)(CBPeripheral *peripheral);
@property (copy, nonatomic) void (^connectDeviceCallBack)(CBPeripheral *peripheral);
@property (copy, nonatomic) void (^disconnectDeviceCallBack)(CBPeripheral *peripheral);
@property (copy, nonatomic) void (^receiverDataCallBack)(CBCharacteristic *characteristic);

+ (BluetoothManager*)instance;
- (void)beginScanDevice;
- (void) stopScanDevice;
-(void)saveToDB:(CBPeripheral *)peripheral forProfile:(Profile*)profile;
-(void)removeToDB:(BluetoothDevice *)device;

@end
