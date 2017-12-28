package nta.med.service.integration.ihis;


import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

public class CPL3020U02SetDataIFS7203HandlerTest extends MessageRequestTest{

    @Test
    public void testCPL3020U02SetDataIFS7203Request() throws Exception {

    	CplsServiceProto.CPL3020U02SetDataIFS7203Request request = CplsServiceProto.CPL3020U02SetDataIFS7203Request.newBuilder()
    			.setRecordGubun("c")
				.setSentaCode("se")
				.setIraiKey("ir")
				.setKaruteNo("kar")
				.setKanjamei("kan")
				.setKoumokusuu("kou")
				.setHoukokubi("hou")
				.setYobi1("yb1")
				.setYobi2("yb2")
    			.build();

        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
