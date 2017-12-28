package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.CommonModelProto.ComboDataSourceInfo;
import nta.med.service.integration.MessageRequestTest;

public class LoadComboDataSourceTest extends MessageRequestTest{

	@Test
    public void test() throws InterruptedException {
        
		CommonModelProto.ComboDataSourceInfo info = ComboDataSourceInfo.newBuilder().setColName("ho_dong").build();
		
		SystemServiceProto.LoadComboDataSourceRequest request = SystemServiceProto.
        		LoadComboDataSourceRequest.newBuilder().setDataInfo(info).build();
		
        sentRequestToMedApp(request, SystemServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
