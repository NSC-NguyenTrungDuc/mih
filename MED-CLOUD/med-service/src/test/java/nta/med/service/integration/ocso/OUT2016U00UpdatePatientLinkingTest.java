package nta.med.service.integration.ocso;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsoModelProto.OUT2016U00PatientLinkingContentInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.integration.MessageRequestTest;

/**
 * @author Tiepnm
 */
public class OUT2016U00UpdatePatientLinkingTest extends MessageRequestTest {

    @Test
    public void testOUT2016U00UpdatePatientLinking() throws InterruptedException {

    	List<OUT2016U00PatientLinkingContentInfo> listInfo = new ArrayList<OUT2016U00PatientLinkingContentInfo>();
    	
    	OUT2016U00PatientLinkingContentInfo.Builder item1 =  OUT2016U00PatientLinkingContentInfo.newBuilder();
    	item1.setHospCodeLink("K01-01");
    	item1.setBunhoLink("000000005");
    	listInfo.add(item1.build());
    	
    	OUT2016U00PatientLinkingContentInfo.Builder item2 =  OUT2016U00PatientLinkingContentInfo.newBuilder();
    	item2.setHospCodeLink("K01-01");
    	item2.setBunhoLink("000000007");
    	listInfo.add(item2.build());
    	
        OcsoServiceProto.OUT2016U00UpdatePatientLinkingRequest request = OcsoServiceProto.OUT2016U00UpdatePatientLinkingRequest.newBuilder().
                setHospCode("K01")
                .setBunho("000001650")
                .addAllPhrPatientLinkingContent(listInfo)
                .build();
        
        sentRequestToMedApp(request, OcsoServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
