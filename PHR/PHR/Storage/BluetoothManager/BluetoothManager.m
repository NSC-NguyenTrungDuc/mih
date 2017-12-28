//
//  BluetoothManager.m
//  PHR
//
//  Created by BillyMobile on 6/13/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BluetoothManager.h"
#import "PHRSample.h"
#import "StorageManager.h"

@implementation BluetoothManager {
    //Timer
    NSTimer *timerScanDevice;
    // list respond data
    NSMutableArray *arrayData;
}

static NSString *CBUUIDGenericAccessProfileString = @"1800";
static NSString *CBUUIDDeviceNameString = @"2A00";


+ (BluetoothManager*)instance{
    static BluetoothManager *instance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        instance = [[BluetoothManager alloc] init];
    });
    return instance;
}

- (instancetype)init{
    if (self == [super init]) {
        NSDictionary *options = @{CBCentralManagerOptionShowPowerAlertKey: @NO};
        self.manager = [[CBCentralManager alloc] initWithDelegate:self queue:nil options:options];
        self.allConnectedDevices = [BluetoothDevice allObjects];
        self.availableConnectedDevices = [NSMutableArray new];
        self.scannedDevices = [NSMutableArray new];
    }
    return self;
}

- (void)startConnectBlueDevice{
    [self.scannedDevices removeAllObjects];
    NSDictionary *options = @{CBCentralManagerOptionShowPowerAlertKey: @NO};
    
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBlueScanNewDevice object:nil];
    
    [self.manager scanForPeripheralsWithServices:@[[CBUUID UUIDWithString:BLEService_HEART_RATE],
                                                   [CBUUID UUIDWithString:BLEService_BLOOD_PRESSURE],
                                                   [CBUUID UUIDWithString:BLEService_BODY_TEMPERATUTE],
                                                   [CBUUID UUIDWithString:BLEService_BODY_COMPOSITION],
                                                   [CBUUID UUIDWithString:BLEService_WEIGHT_SCALE]] options:options];
}

- (void)beginScanDevice{
    // scan device in 5s
    timerScanDevice = [NSTimer scheduledTimerWithTimeInterval:5 target:self selector:@selector(startConnectBlueDevice) userInfo:nil repeats:YES];
}

// stop scan bluetooth device
- (void) stopScanDevice{
    if(timerScanDevice){
        [timerScanDevice invalidate];
        [self.manager stopScan];
    }
}

//Every time we successfully connect to a peripheral this function will be called
- (void)centralManager:(CBCentralManager *)central didConnectPeripheral:(CBPeripheral *)peripheral{
    NSLog(@"Connected to %@", peripheral.name);
    
    arrayData = [NSMutableArray new];
    
    //we'll save the reference, we'll use it when writing data
    self.mainPeripheral = peripheral;
    //self.connectDeviceCallBack(peripheral);
    //set delegate and discover all available services
    [peripheral setDelegate:self];
    [peripheral discoverServices:nil];
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBlueConnectDevice object:peripheral];
}

//This function is invoked after a connected device is disconnected, we also remove reference of its delegate
- (void)centralManager:(CBCentralManager *)central didDisconnectPeripheral:(CBPeripheral *)peripheral error:(NSError *)error{
    NSLog(@"%@ disconnected...", peripheral.name);
    [self checkDisconnected:peripheral];
    [peripheral setDelegate:nil];
    
    if([arrayData count] > 0){
        CBCharacteristic *characteristic = [arrayData objectAtIndex:0];
        [self parseData:characteristic withDevice:peripheral];
        [arrayData removeAllObjects];
    }
    
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBlueDisconnectDevice object:peripheral];
}

//If any error ocurrs it will be notified in this function
- (void)centralManager:(CBCentralManager *)central didFailToConnectPeripheral:(CBPeripheral *)peripheral error:(NSError *)error{
    NSLog(@"Connect fail%@", error);
}

//Add any discovered peripheral to the peripherals array
-(void)centralManager:(CBCentralManager *)central didDiscoverPeripheral:(CBPeripheral *)peripheral advertisementData:(NSDictionary *)advertisementData RSSI:(NSNumber *)RSSI{
    if(![self.availableConnectedDevices containsObject:peripheral] && ![self.scannedDevices containsObject:peripheral]){
        [self checkConnectDevice:peripheral];
    }
    
    DLog(@"Number Service : %lu",[peripheral.services count]);
    
    // self.findDeviceCallBack(peripheral);
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBlueScanNewDevice object:peripheral];
//    for (CBService *ser in peripheral.services){
//        DLog(@"Service: %@",ser.UUID);
//    }
    DLog(@"Number of Device: %ld",[self.availableConnectedDevices count] + [self.scannedDevices count]);
}

//The manager detects the bluetooth state from the iOS device and notifies
- (void)centralManagerDidUpdateState:(CBCentralManager *)central{
    char* managerStrings[] = {
        "Unknown", "Resetting", "Unsupported","Unauthorized", "PoweredOff", "PoweredOn"
    };
    
    NSString *auxString = [NSString stringWithFormat:@"Manager State: %s", managerStrings[central.state]];
    NSLog(@"%@", auxString);
}

#pragma mark CBPeripheral Delegate

- (void) peripheral:(CBPeripheral *)aPeripheral didDiscoverServices:(NSError *)error{
    for (CBService *aService in aPeripheral.services){
        NSLog(@"Service found with UUID: %@", aService.UUID);
        
        /* Device Information Service */
        if ([aService.UUID isEqual:[CBUUID UUIDWithString:@"180A"]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        
        /* GAP (Generic Access Profile) for Device Name */
        if ([aService.UUID isEqual:[CBUUID UUIDWithString:CBUUIDGenericAccessProfileString]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        
        /* Bluno Service */
        else if([aService.UUID isEqual:[CBUUID UUIDWithString:BLEService_HEART_RATE]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        /* Bluno Service */
        else if([aService.UUID isEqual:[CBUUID UUIDWithString:BLEService_BLOOD_PRESSURE]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        else if([aService.UUID isEqual:[CBUUID UUIDWithString:BLEService_BODY_TEMPERATUTE]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        else if([aService.UUID isEqual:[CBUUID UUIDWithString:BLEService_BODY_COMPOSITION]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
        else if([aService.UUID isEqual:[CBUUID UUIDWithString:BLEService_WEIGHT_SCALE]]){
            [aPeripheral discoverCharacteristics:nil forService:aService];
        }
    }
}

- (void) peripheral:(CBPeripheral *)aPeripheral didDiscoverCharacteristicsForService:(CBService *)service error:(NSError *)error{
    
    if ([service.UUID isEqual:[CBUUID UUIDWithString:BLEService_BLOOD_PRESSURE]]){
        for (CBCharacteristic *aChar in service.characteristics){
            /* Read DATA Characteristic */
            if ([aChar.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_BLOOD_PRESSURE]]){
                //we'll save the reference, needed when writing data
                self.mainCharacteristic = aChar;
                [aPeripheral setNotifyValue:YES forCharacteristic:aChar];
                NSLog(@"Blood Pressure DATA Characteristic");
            }
        }
    }
    else if ([service.UUID isEqual:[CBUUID UUIDWithString:BLEService_HEART_RATE]]){
        for (CBCharacteristic *aChar in service.characteristics){
            /* Read DATA Characteristic */
            if ([aChar.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_HEART_RATE]]){
                //we'll save the reference, needed when writing data
                self.mainCharacteristic = aChar;
                [aPeripheral setNotifyValue:YES forCharacteristic:aChar];
                NSLog(@"Heart rate DATA Characteristic");
            }
        }
    }else if ([service.UUID isEqual:[CBUUID UUIDWithString:BLEService_BODY_TEMPERATUTE]]){
        for (CBCharacteristic *aChar in service.characteristics){
            DLog(@"CHARACTERRISTIC :%@",aChar.UUID);
            /* Read DATA Characteristic */
            if ([aChar.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_BODY_TEMPERATUTE]]){
                //we'll save the reference, needed when writing data
                self.mainCharacteristic = aChar;
                [aPeripheral setNotifyValue:YES forCharacteristic:aChar];
                NSLog(@"Body temperature DATA Characteristic");
            }
        }

    }else if ([service.UUID isEqual:[CBUUID UUIDWithString:BLEService_BODY_COMPOSITION]]){
        for (CBCharacteristic *aChar in service.characteristics){
            /* Read DATA Characteristic */
            if ([aChar.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_Body_Composition]]){
                //we'll save the reference, needed when writing data
                self.mainCharacteristic = aChar;
                [aPeripheral setNotifyValue:YES forCharacteristic:aChar];
                NSLog(@"Body Composition DATA Characteristic");
            }
        }
        
    }
    
    else if ([service.UUID isEqual:[CBUUID UUIDWithString:BLEService_WEIGHT_SCALE]]){
        for (CBCharacteristic *aChar in service.characteristics){
            /* Read DATA Characteristic */
            if ([aChar.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_Weight_Scale]]){
                //we'll save the reference, needed when writing data
                self.mainCharacteristic = aChar;
                [aPeripheral setNotifyValue:YES forCharacteristic:aChar];
                NSLog(@"Body Composition DATA Characteristic");
            }
        }
        
    }
}

- (void) peripheral:(CBPeripheral *)aPeripheral didUpdateValueForCharacteristic:(CBCharacteristic *)characteristic error:(NSError *)error{
    
    /* Value for received */
    DLog(@"Value--->%@  and UUID------>%@",characteristic.value,characteristic.UUID);
    if([characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_HEART_RATE]]){
        [self parseData:characteristic withDevice:aPeripheral];
    }else{
        [arrayData addObject:characteristic];
    }
}

#pragma mark - Save device to DB
-(void)saveToDB:(CBPeripheral *)peripheral forProfile:(Profile*)profile{
    RLMRealm *realm = [RLMRealm defaultRealm];
    [realm beginWriteTransaction];
    BluetoothDevice *device = [[BluetoothDevice alloc] init];
    device.deviceID = [peripheral.identifier UUIDString];
    device.deviceName = peripheral.name;
    device.userActiveID = profile.profileId;
    device.useForBaby = profile.isBaby;
    device.userName = profile.name;
    
    [realm addObject:device];
    [realm commitWriteTransaction];
    
    self.allConnectedDevices = [BluetoothDevice allObjects];
}

-(void)removeToDB:(BluetoothDevice *)device{
    RLMRealm *realm = [RLMRealm defaultRealm];
    [realm beginWriteTransaction];
    [realm deleteObject:device];
    [realm commitWriteTransaction];
    
    self.allConnectedDevices = [BluetoothDevice allObjects];
}

-(void) checkConnectDevice:(CBPeripheral *)peripheral{
    if([self.allConnectedDevices count] > 0){
        for (BluetoothDevice *device in self.allConnectedDevices){
            DLog(@"Device %@ and %@",device.deviceID,[peripheral.identifier UUIDString])
            if([[peripheral.identifier UUIDString] isEqualToString:device.deviceID]){
                [self.availableConnectedDevices addObject:peripheral];
                // NOTE: connect device after discover
                [self.manager connectPeripheral:peripheral options:nil];
                break;
            }else{
                [self.scannedDevices addObject:peripheral];
            }
        }
    } else {
        [self.scannedDevices addObject:peripheral];
    }
}

-(void) checkDisconnected:(CBPeripheral *)peripheral{
    if([self.availableConnectedDevices containsObject:peripheral]){
        [self.availableConnectedDevices removeObject:peripheral];
    }else if([self.scannedDevices containsObject:peripheral]){
        [self.scannedDevices removeObject:peripheral];
    }
}


#pragma mark - sync blurtooth data
-(void) parseData:(CBCharacteristic *)characteristic withDevice:(CBPeripheral *)peripheral{
    BluetoothDevice *device = nil;
    for (BluetoothDevice *temp in self.allConnectedDevices) {
        if([[peripheral.identifier UUIDString] isEqualToString:temp.deviceID]){
            device = temp;
            break;
        }
    }
    PHRSample *sample = nil;
    if ([characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_HEART_RATE]]
        || [characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_BODY_TEMPERATUTE]]
        || [characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_Body_Composition]]
        || [characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_Weight_Scale]]){
        
        // process data
        if([PHRSample getValueForBluetooth:characteristic] > 1000){
            return;
        }
        sample = [[PHRSample alloc] initWithCharacteristic:characteristic profileId:device.userActiveID];
    }
    /* Data received */
    else if ([characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_BLOOD_PRESSURE]]){
        sample = [[PHRSample alloc] initWithCharacteristicBloodPressure:characteristic profileId:device.userActiveID];
        uint16_t systolic = *(uint16_t*)[[characteristic.value subdataWithRange:NSMakeRange(1, 2)] bytes];
        if([PHRSample parseBloodPressureObj:systolic] > 1000){
            return;
        }
    }
    
    //    if([characteristic.UUID isEqual:[CBUUID UUIDWithString:BLECharacteristic_Weight_Scale]]){
    //        NSUInteger len = [characteristic.value length];
    //        Byte *byteData = (Byte*)malloc(len);
    //        memcpy(byteData, [characteristic.value bytes], len);
    //
    //        DLog(@"Length Val:%lu",(unsigned long)len);
    //
    //        uint16_t bmi = *(uint16_t*)[[characteristic.value subdataWithRange:NSMakeRange(4, 2)] bytes];
    //        sample = [[PHRSample alloc] initWithBMI_Value:(bmi/100) profileId:PHRAppStatus.currentStandard.profileId];
    //
    //    }
    if (sample) {
        [[StorageManager instance] savePHRSample:sample];
        if(device.useForBaby){
            [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBluetoothDataForBaby object:sample];
        }else{
            [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyBluetoothData object:sample];
        }
    }
}

@end
