package nta.med.service.integration.nuro;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author DEV-NgocNV
 *
 */
public class NUR2016Q00GrdHospListHandlerTest extends MessageRequestTest{

    @Test
    public void testNUR2016Q00GrdHospListHandlerTest() throws Exception {
    	
    	NuroServiceProto.NUR2016Q00GrdHospListRequest request = NuroServiceProto.NUR2016Q00GrdHospListRequest.newBuilder()
    			.setHospCode("346")
    			.setYoyangName("三杯")
    			.setAddress("北海道札幌市北区北十四条西（１～４丁目）")  	
    			.setOffset("20")
    			.setPageNumber("1")
    			.build();
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
