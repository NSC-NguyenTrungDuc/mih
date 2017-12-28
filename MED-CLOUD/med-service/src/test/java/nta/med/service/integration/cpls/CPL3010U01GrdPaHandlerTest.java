package nta.med.service.integration.cpls;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;


public class CPL3010U01GrdPaHandlerTest extends MessageRequestTest{

    @Test
    public void testCPL3010U01GrdPaRequest() throws Exception {
    	CplsServiceProto.CPL3010U01GrdPaRequest request = CplsServiceProto.CPL3010U01GrdPaRequest.newBuilder()
        		.setCenterCode("A")
        		.setUitakCode("01")
				.setFromPartJubsuDate("2015/09/28")
				.setToPartJubsuDate("2015/09/28")
				.setFromSeq("0700")
				.setToSeq("2400")
				.setFromSpecimenSer("15092500001")
				.setToSpecimenSer("15092599999")
				.setUitakCode("00")
				.setCenterCode("SAN ").setCbxJubsuDate(true)

				.build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
