package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ORDERTRANPRMakeIFS1004HandlerTest extends MessageRequestTest {

	@Test
	public void testORDERTRANPRMakeIFS1004Handler() throws InterruptedException {
		NuroServiceProto.ORDERTRANPRMakeIFS1004Request.Builder request = NuroServiceProto.ORDERTRANPRMakeIFS1004Request.newBuilder();
		NuroModelProto.ORDERTRANPRMakeIFS1004Info.Builder info = NuroModelProto.ORDERTRANPRMakeIFS1004Info.newBuilder();
		info.setHospCode("K01");
		info.setIoGubun("I");
		info.setPkout1003("1");
		info.setTransYn("Y");
		info.setTransGubun("SANG");

		request.addInputInfo(info.build());
		
		sentRequestToMedApp(request.build(), NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
