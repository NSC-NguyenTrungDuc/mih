package nta.med.service.integration.inps;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsModelProto.INP3003U00grdINP1001Info;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;


public class INPINP3003U00U00SaveLayoutTest extends MessageRequestTest {
    @Test
    public void testINPINP3003U00U00SaveLayout() throws InterruptedException {
    	
    	List<INP3003U00grdINP1001Info> listInfo = new ArrayList<INP3003U00grdINP1001Info>();
    		
    	INP3003U00grdINP1001Info.Builder info =  INP3003U00grdINP1001Info.newBuilder();
    	info.setPkinp1001("0123");
    	info.setResultAfterDis("N");
    	info.setResultAfterDisRemark("n2");
    	
    	listInfo.add(info.build());
    	 	
    	InpsServiceProto.INP3003U00SaveLayoutRequest request = InpsServiceProto.INP3003U00SaveLayoutRequest.newBuilder().build();
    	
        sentRequestToMedApp(request, InpsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
