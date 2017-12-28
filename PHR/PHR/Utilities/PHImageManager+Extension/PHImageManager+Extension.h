//
//  PHImageManager+Extension.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/29/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Photos/Photos.h>

@interface PHImageManager (CTAssetsPickerController)

- (PHImageRequestID)ctassetsPickerRequestImageForAsset:(PHAsset *)asset targetSize:(CGSize)targetSize contentMode:(PHImageContentMode)contentMode options:( PHImageRequestOptions *)options resultHandler:(void (^)(UIImage * result, NSDictionary * info))resultHandler;

@end
