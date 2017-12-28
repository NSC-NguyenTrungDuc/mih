//
//  PHRViewUploadFile.h
//  PHR
//
//  Created by DEV-MinhNN on 11/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol PHRViewUploadFileDelegate <NSObject>
@optional
- (void)deleteFileUpload:(UIButton *)btn;
- (void)showImage:(UIImageView *)imageView;

@end

@interface PHRViewUploadFile : UIView {
    NSMutableArray *_listImage;
}

@property (nonatomic, strong) id<PHRViewUploadFileDelegate> delegate;

- (void)addViewNameFileUploadInParentView:(NSArray *)arrayFileNameUpload andListFileName:(NSMutableArray *)arrayFileName;
- (void)addViewContainFileServerInParentView:(NSArray *)arrayFileImage;

@end
