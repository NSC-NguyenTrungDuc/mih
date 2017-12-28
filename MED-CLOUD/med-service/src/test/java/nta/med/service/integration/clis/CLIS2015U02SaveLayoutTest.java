package nta.med.service.integration.clis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisModelProto;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CLIS2015U02SaveLayoutTest extends MessageRequestTest {
    @Test
    public void testCLIS2015U02SaveLayout() throws InterruptedException {

    	ClisModelProto.CLIS2015U02GrdProtocolInfo.Builder  info = ClisModelProto.CLIS2015U02GrdProtocolInfo.newBuilder();
    	info.setProtocolCode("PRU");
    	info.setProtocolName("PUR1");
    	info.setFromDate("2016/03/03");
    	info.setToDate("2016/03/04");
    	info.setProtocolStatus("00");
    	info.setRowState("Added");
    	info.setProtocolId("2");
    	
    	ClisServiceProto.CLIS2015U02SaveLayoutRequest request = ClisServiceProto.
        		CLIS2015U02SaveLayoutRequest.newBuilder()
        		.setGrdProtocolList(info)
                .build();

        sentRequestToMedApp(request, ClisServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
