package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INPBATCHTRANSisJaewonPatientHandlerTest extends MessageRequestTest{
	@Test
	public void test () throws Exception{
		
		InpsServiceProto.INPBATCHTRANSisJaewonPatientRequest request = InpsServiceProto.INPBATCHTRANSisJaewonPatientRequest.newBuilder()
				.setBunho("000000002")
				.setQueryDate("2016/11/11")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
